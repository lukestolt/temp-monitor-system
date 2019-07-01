namespace Models.ResponseModels
{
    public class ResponseModel
    {
        public enum Responses
        {
            Success,
            Error
        }
        public string response;

        public ResponseModel(Responses resp)
        {
            if(resp.Equals(Responses.Success))
            {
                this.response = "Success";
            }
            else if(resp.Equals(Responses.Error))
            {
                this.response = "Error";
            }
        }    
    }
}