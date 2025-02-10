using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.AcaValidation;

public class AcaValidator
{
    private StudentAddModel Model { get; set; }

    public AcaValidator(StudentAddModel model)
    {
        Model = model;
    }

    private ICollection<Func<StudentAddModel, AcaValidationResult>> ValidationMethods = new List<Func<StudentAddModel, AcaValidationResult>>();

    public void AddRule(Func<StudentAddModel, AcaValidationResult> rule)
    {
        ValidationMethods.Add(rule);
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
        var result = AcaValidationResult.Success();
        foreach (var method in ValidationMethods)
        {
            var r = method.Invoke(Model);
            if (!r.IsValid)
            {
                result.IsValid = false;
                result.ErrorMessages.AddRange(r.ErrorMessages);
            }
        }
        return result;
    }
}

public class AcaValidationResult
{
    public bool IsValid { get; set; }
    public List<string> ErrorMessages { get; set; } = new List<string>();

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