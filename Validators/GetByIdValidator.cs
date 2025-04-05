namespace WebApi.Validators
{
	public class GetByIdValidator : AbstractValidator<GetByIdQuery>
	{
		public GetByIdValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id boþ olamaz");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan büyük olmalýdýr");
		}
	}
}