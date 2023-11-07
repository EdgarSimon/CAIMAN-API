using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Interfaces;
using FluentValidation;

namespace Cnx.Caiman.Infrastructure.Validators
{
    public class ShipperInsertValidator: AbstractValidator<ShipperInsertDto>
    {
        private IUnitOfWork unitOfWork;
        public ShipperInsertValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            RuleFor(shipper => shipper.Nombre)
                .Must(UniqueName).WithMessage("El transportista ya existe nombre")
                .NotNull();
                
            RuleFor(shipper => shipper.Zona)
                .NotEqual(0).WithMessage("'Zona' must not be equal to '0' ...");

            RuleFor(shipper => shipper.Tarifa)
                .NotNull();


            RuleFor(shipper => shipper.CostoTarifa)
                .NotNull();

            RuleFor(shipper => shipper.Servirprioridad)
                .NotNull();

            RuleFor(shipper => shipper.ICantSencillos)
                .NotNull();

            RuleFor(shipper => shipper.Propio)
                .NotNull();
        }

        private bool UniqueName(ShipperInsertDto shipper, string name)
        {
            return true;
        }

    }
}