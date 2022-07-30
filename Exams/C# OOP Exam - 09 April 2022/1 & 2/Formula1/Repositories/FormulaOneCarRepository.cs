namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get => this.models;
        }
        public object First { get; internal set; }

        public void Add(IFormulaOneCar car)
        {
            this.models.Add(car);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }
    }
}
