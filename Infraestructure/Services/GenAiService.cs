using Microsoft.ML.OnnxRuntimeGenAI;
using System.Runtime.CompilerServices;

namespace NexusNova.Infraestructure.Services;

public sealed class GenAiService
{
    private Model _model;
    private Tokenizer _tokenizer;
    private bool _initialized;

    public async Task InitializeAsync()
    {
        if(_initialized) return;

        _model = new Model("path/to/your/model.onnx");
        _tokenizer = new Tokenizer(_model);
        _initialized = true;
    }

    public async IAsyncEnumerable<string> GenerateResponseAsync(string prompt, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if(!_initialized) await InitializeAsync();

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
