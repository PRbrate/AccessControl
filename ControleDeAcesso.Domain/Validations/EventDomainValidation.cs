using ControleDeAcesso.Domain.Entites;
using FluentValidation;

namespace AccessControl.Domain.Validations
{
    public class EventDomainValidation : AbstractValidator<EventDomain>
    {
        public EventDomainValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do evento é obrigatório.")
                .Length(2, 100).WithMessage("O nome do evento deve ter entre 2 e 100 caracteres.");

            RuleFor(x => x.QuantParticipants)
                .GreaterThan(0).WithMessage("A quantidade de participantes deve ser maior que zero.");

            RuleFor(x => x.EventDate.Date)
                .NotEmpty().WithMessage("A data do evento é obrigatória.")
                .GreaterThan(DateTime.Now.Date).WithMessage("A data do evento deve ser futura.");

            RuleFor(x => x.MaxPeaples)
                .GreaterThanOrEqualTo(x => x.QuantParticipants).WithMessage("O número máximo de pessoas deve ser maior que a quantidade de participantes.");
        }
    }
}
