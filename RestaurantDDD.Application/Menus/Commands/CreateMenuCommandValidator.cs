using FluentValidation;

namespace RestaurantDDD.Application.Menus.Commands
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {

            RuleFor(menuCommand => menuCommand.Name).NotEmpty();
            RuleFor(menuCommand => menuCommand.Description).NotEmpty();
            RuleFor(menuCommand => menuCommand.Sections).NotEmpty();
            RuleFor(menuCommand => menuCommand.Sections.All(section => section.Items.Count() !=0))
             
            .Equals(true);
         
        }
    }
}
