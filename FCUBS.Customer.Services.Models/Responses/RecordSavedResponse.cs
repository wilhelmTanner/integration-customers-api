namespace FCUBS.Customer.Service.Common.Models.Responses
{
    public class RecordSavedResponse
    {

        private bool _success = true;
        public RecordSavedResponse()
        {
                Success = _success;
        }
        /// <summary>
        /// Resultado
        /// </summary>
        public bool Success { get => _success; set => _success = value; }

        /// <summary>
        /// Error interno
        /// </summary>
        public bool InternalError { get; set; }

        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
