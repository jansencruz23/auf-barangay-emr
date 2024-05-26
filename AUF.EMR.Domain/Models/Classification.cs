namespace AUF.EMR.MVC.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Selected { get; set; }
    }
}
