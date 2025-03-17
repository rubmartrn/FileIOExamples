using UniversityProgram.BLL.Models;

namespace UniversityProgram.Api.AcaValidation;

public class AcaValidator
{
    private StudentAddModel Model { get; set; }

    public AcaValidator(StudentAddModel model)
    {
        Model = model;
    }

    private ICollection<Rule> Rules = new List<Rule>();
    private ICollection<RuleAsync> RulesAsync = new List<RuleAsync>();


    public void AddRule(Func<StudentAddModel, bool> rule, string errorMessage)
    {
        Rules.Add(new Rule(rule, errorMessage));
    }

    public void AddRule(Func<StudentAddModel, Task<bool>> rule, string errorMessage)
    {
        RulesAsync.Add(new RuleAsync(rule, errorMessage));
    }

    //private AcaValidationResult NotNull(StudentAddModel model)
    //{
    //    if (model.Name is null)
    //    {
    //        return AcaValidationResult.Fail("Model is null");
    //    }
    //    return AcaValidationResult.Success();
    //}

    public async Task<AcaValidationResult> Validate()
    {
        var result = AcaValidationResult.Success();
        foreach (var rule in Rules)
        {
            var b = rule.Method.Invoke(Model);
            if (!b)
            {
                result.IsValid = false;
                result.ErrorMessages.Add(rule.ErrorMessage);
            }
        }

        foreach (var rule in RulesAsync)
        {
            var b = await rule.Method.Invoke(Model);
            if (!b)
            {
                result.IsValid = false;
                result.ErrorMessages.Add(rule.ErrorMessage);
            }
        }

        return result;
    }
}

record Rule(Func<StudentAddModel, bool> Method, string ErrorMessage);
record RuleAsync(Func<StudentAddModel, Task<bool>> Method, string ErrorMessage);

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