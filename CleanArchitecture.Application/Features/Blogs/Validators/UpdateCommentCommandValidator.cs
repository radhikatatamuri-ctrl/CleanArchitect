using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using CleanArchitecture.Application.Features.Blogs.Commands;

namespace CleanArchitecture.Application.Features.Blogs.Validators
{

    public class UpdateBlogCommandValidator
        : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            RuleFor(x => x.blogId)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Author)
                .NotEmpty();

            RuleFor(x => x.ImageUrl)
                .NotEmpty();
        }
    }
}
