namespace UniversityProgram.Api.Services
{
    public class CourseBankServiceApi
    {
        //Կեղծ փոխանցում համալսարանի հաշվեհամարին
        public bool PayCourse(int id)
        {
            if (id == 2)
            {
                return true;
            }

            throw new Exception("Բանկն անհասանելի է");
        }
    }
}
