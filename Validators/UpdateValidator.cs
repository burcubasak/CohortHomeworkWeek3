namespace WebApi.Validators
{
    public class UpdateValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id bo� olamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan b�y�k olmal�d�r");
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Kitap ad� bo� olamaz");
            RuleFor(x => x.Model.Writer).NotEmpty().WithMessage("Yazar ad� bo� olamaz");
            RuleFor(x => x.Model.Publisher).NotEmpty().WithMessage("Yay�nevi ad� bo� olamaz");
        }
    }
}