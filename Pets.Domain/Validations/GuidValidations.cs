using System;

namespace Pets.Domain.Validations
{
    public static class GuidValidations
    {
        public static bool IsGuid(object guid)
        {
            return (guid is Guid ? true : false);
        }
    }
}