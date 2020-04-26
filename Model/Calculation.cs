using System;
using Siemens.TcPCM.Annotations;

namespace Model
{
    public class Calculation : IPersistableObject
    {
        [NotNull]
        private readonly IBusinessContext _businessContext;

        public Calculation([NotNull] IBusinessContext businessContext)
        {
            _businessContext = businessContext ?? throw new ArgumentNullException(nameof(businessContext));
        }

        public string Name
        {
            get => _businessContext.GetTransalation(this, nameof(Name));
            set => _businessContext.SetTranslation(this, nameof(Name), value);
        }
    }

    public interface IBusinessContext
    {
        string GetTransalation([NotNull] IPersistableObject persistableObject, [NotNull] string propertyName);
        void SetTranslation([NotNull] IPersistableObject persistableObject, [NotNull] string propertyName, [NotNull] string value);
    }

    public interface IPersistableObject
    {
        
    }
}