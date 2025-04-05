namespace WebApi.Validators
{
    public class UpdateValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boþ olamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan büyük olmalýdýr");
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Kitap adý boþ olamaz");
            RuleFor(x => x.Model.Writer).NotEmpty().WithMessage("Yazar adý boþ olamaz");
            RuleFor(x => x.Model.Publisher).NotEmpty().WithMessage("Yayýnevi adý boþ olamaz");
        }
    }
}