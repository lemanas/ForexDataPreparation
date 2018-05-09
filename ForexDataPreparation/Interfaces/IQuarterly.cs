namespace ForexDataPreparation.Interfaces
{
    public interface IQuarterly
    {
        int Year { get; set; }
        int Quarter { get; set; }
        double Difference { get; set; }
    }
}
