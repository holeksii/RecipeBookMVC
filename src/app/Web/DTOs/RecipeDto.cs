namespace Web.DTOs
{
    public class RecipeDto
    {
        public long Id { get; set; }

        public int TimeToCook { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public long UserId { get; set; }

        public List<IngredientDto> Ingredients = new List<IngredientDto>();
    }
}
