namespace ServisYonetimPanel.Common.Response
{
    public class ServiceResponse<T>
    {
        public T ResponseData { get; set; }
    }

    public class ServiceResponse
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }
    }
}