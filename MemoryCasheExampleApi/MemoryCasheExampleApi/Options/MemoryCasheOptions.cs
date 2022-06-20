namespace MemoryCasheExampleApi.Options;

public abstract class MemoryCasheOptions
{
    //Enable required field when  options validation is necassary
    //[Required]
    public int SlidingExpirationSeconds { get; set; }

    //[Required]
    public int AbsoluteExpirationSeconds { get; set; }

    //[Required]
    public int SizeLimitInMB { get; set; }
}