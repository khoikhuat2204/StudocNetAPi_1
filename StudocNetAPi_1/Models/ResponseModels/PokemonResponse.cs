namespace StudocNetAPi_1.Models.ResponseModels
{
    public class PokemonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<ReviewResponse> Reviews { get; set; }
        public List<CategoryResponse> Categories { get; set; }
    }
}
