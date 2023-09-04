namespace CGOL.Lib.Services.Interfaces;

public interface IOptionsValidator<in TOptions> where TOptions : notnull
{
    public void ValidateOptionsThrow(TOptions options);
}