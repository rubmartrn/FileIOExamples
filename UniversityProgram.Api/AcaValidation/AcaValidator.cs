using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.AcaValidation;

public class AcaValidator
{
    private StudentAddModel Model { get; set; }
    public AcaValidator(StudentAddModel model)
    {
        Model = model;
    }

    private Func<StudentAddModel, AcaValidationResult> ValidationMethod;

    public void AddRule(Func<StudentAddModel, AcaValidationResult> rule)
    {
        ValidationMethod = rule;
    }


    //private AcaValidationResult NotNull(StudentAddModel model)
    //{
    //    if (model.Name is null)
    //    {
    //        return AcaValidationResult.Fail("Model is null");
    //    }
    //    return AcaValidationResult.Success();
    //}

    public AcaValidationResult Validate()
    {
        return ValidationMethod.Invoke(Model);
    }
}

public class AcaValidationResult
{
    public bool IsValid { get; set; }
    public ICollection<string> ErrorMessages { get; set; } = new List<string>();

    public void AddError(string message)
    {
        ErrorMessages.Add(message);
    }

    public static AcaValidationResult Success()
    {
        return new AcaValidationResult { IsValid = true };
    }

    public static AcaValidationResult Fail(string message)
    {
        return new AcaValidationResult { IsValid = false, ErrorMessages = new List<string> { message } };
    }
}