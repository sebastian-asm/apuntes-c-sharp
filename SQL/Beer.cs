namespace SQL
{
    public class Beer
    {
        public int id { get; set; }
        public string name { get; set; }
        public int brandId { get; set; }

        public Beer(int id, string name, int brandId)
        {
            this.id = id;
            this.name = name;
            this.brandId = brandId;
        }

        // sobrecarga del constructor para no recibir el id
        // al momento de guardar los datos en la db
        public Beer(string name, int brandId)
        {
            this.name = name;
            this.brandId = brandId;
        }
    }
}
