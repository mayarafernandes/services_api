namespace Company.Services.Infrasctructure.Models
{
    public class AnswerDTO<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool HasError { get { return !string.IsNullOrEmpty(Message); } }

        public AnswerDTO() { }

        public AnswerDTO(T data)
        {
            Data = data;
        }

        public AnswerDTO<TNew> To<TNew>()
        {
            return new AnswerDTO<TNew>() { Message = this.Message };
        }
    }
}