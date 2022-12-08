namespace DesignHelper.Infrastructure.Constrains
{
    public class ConstrainValidations
    {
        //Title
        public const int TitleMinLength = 3;
        public const int TitleMaxLength = 50;

        //Author
        public const int AuthorMinLength = 3;
        public const int AuthorMaxLength = 100;

        //Location
        public const int LocationMinLength = 3;
        public const int LocationMaxLength = 100;

        //Desctription
        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 1000;

        //Category
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;

        //Rating
        public const string RatingMinLength = "0.00";
        public const string RatingMaxLength = "10.00";

        //Area
        public const double AreaMinLength = 0.00;
        public const double AreaMaxLength = 10000.00;

        //Awards
        public const int AwardsNameMinLength = 3;
        public const int AwardsNameMaxLength = 100;

        //ToolsUsed
        public const int ToolsUsedNameMinLength = 3;
        public const int ToolsUsedNameMaxLength = 30;

        //UserFirstName
        public const int UserFirstNameMinLength = 1;
        public const int UserFirstNameMaxLength = 30;

        //UserLastName
        public const int UserLastNameMinLength = 1;
        public const int UserLastNameMaxLength = 30;
    }
}
