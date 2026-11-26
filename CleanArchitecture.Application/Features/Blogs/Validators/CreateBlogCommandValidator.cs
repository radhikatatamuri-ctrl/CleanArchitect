using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using CleanArchitecture.Application.Features.Blogs.Commands;


namespace CleanArchitecture.Application.Features.Blogs.Validators
{

    public class CreateBlogCommandValidator
        : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Blog name is required");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Author is required");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("Image URL is required");
        }
    }
}
