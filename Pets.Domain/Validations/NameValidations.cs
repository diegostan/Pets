using Pets.Domain.ValueObjects;

namespace Pets.Domain.Validations
{
    public static class NameValidations
    {
        public static bool FirstNameIsNotNull(Name name)
        {
            if (string.IsNullOrEmpty(name.FirstName))
                return true;

            return false;
        }

        public static bool LastNameIsNotNull(Name name)
        {
            if (string.IsNullOrEmpty(name.LastName))
                return true;
                                    
            return false;
        }

        public static bool FirstIsLenghtOk(Name name, short minLenght, short maxLenght)
        {
            if ((name.FirstName.Length < minLenght) || (name.FirstName.Length > maxLenght))
                return true;
            
            return false; 
        }

         public static bool LastIsLenghtOk(Name name, short minLenght, short maxLenght)
        {
            if ((name.LastName.Length < minLenght) || (name.LastName.Length > maxLenght))
                return true;
            
            return false; 
        } 
    }
}