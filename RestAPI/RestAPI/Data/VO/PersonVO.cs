namespace RestAPI.Data.Converter.VO
{  
    public class PersonVO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public bool IsEmpty()
        {
            bool isEmpty = false;

            if (FirstName == null && LastName == null && Address == null && Gender == null)
                isEmpty = true;

            return isEmpty;
        }
    }
}
