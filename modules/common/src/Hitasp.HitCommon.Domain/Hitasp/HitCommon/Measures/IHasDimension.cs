namespace Hitasp.HitCommon.Measures
{
    public interface IHasDimension
    {
        string WeightUnit { get; }
        decimal? Weight { get; }
        string MeasureUnit { get; }
        decimal? Height { get; }
        decimal? Length { get; }
        decimal? Width { get; }
    }
}