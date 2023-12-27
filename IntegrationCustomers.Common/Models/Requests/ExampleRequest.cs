namespace IntegrationCustomers.Common.Models.Requests;

public class ExampleRequest
{        
    [JsonPropertyName("Descripcion")]
    public string Description { get; set; }

    [JsonPropertyName("Valor")]
    public int Value { get; set; }

    [JsonPropertyName("Tipo")]
    [JsonConverter(typeof(StringConverterValidator<ExampleTypeEnum>))]
    public ExampleTypeEnum ExampleType { get; set; }
}