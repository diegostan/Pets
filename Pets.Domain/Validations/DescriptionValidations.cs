namespace Pets.Domain.Validations
{
    public static class DescriptionValidations
    {
         public static bool DescriptionIsNotNull(string description)
        {
            if (string.IsNullOrEmpty(description))
                return true;
                                    
            return false;
        }

        public static bool DescriptionLenghtOk(string description, short minLenght, short maxLenght)
        {
            if ((description.Length < minLenght) || (description.Length > maxLenght))
                return true;
            
            return false; 
        }
    }
}