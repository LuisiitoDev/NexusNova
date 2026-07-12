using Microsoft.ML.OnnxRuntimeGenAI;
using NexusNova.Core.Interfaces;
using System.Runtime.CompilerServices;

namespace NexusNova.Infraestructure.Services;

public sealed class InferenceService : IInferenceService
{
    private readonly Model _model;
    private readonly Tokenizer _tokenizer;

    public InferenceService(string path)
    {
        _model = new Model(path);
        _tokenizer = new Tokenizer(_model);
    }

    public async IAsyncEnumerable<string> GenerateResponseAsync(string prompt, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        using var sequences = _tokenizer.Encode(prompt);
        using var generatorParams = new GeneratorParams(_model);
        generatorParams.SetSearchOption("max_length", 100);

        using var generator = new Generator(_model, generatorParams);
        generator.AppendTokenSequences(sequences);

        while(!generator.IsDone() && !cancellationToken.IsCancellationRequested)
        {
            await Task.Run(() => generator.GenerateNextToken(), cancellationToken);

            var sequence = generator.GetSequence(0);
            int lastTokenId = sequence[^1];

            yield return _tokenizer.Decode([lastTokenId]);
        }
    }
}
