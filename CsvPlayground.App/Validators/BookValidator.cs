using System.Collections.Generic;
using CsvPlayground.App.Dto;
using FluentValidation;

namespace CsvPlayground.App.Validators
{
    public class BooksValidator : AbstractValidator<IEnumerable<BookDto>>
    {
        public BooksValidator()
        {

            RuleFor(books => books)
            .NotEmpty()
            .WithMessage(books => $"Books can`t be empty.");
            RuleForEach(books => books)
            .SetValidator(new BookValidator());

        }
    }

    class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Categories)
                .NotEmpty()
                .WithMessage("Can`t have a book without categories");

            RuleFor(book => book.Name)
                .NotEmpty()
                .WithMessage("Can`t have a book without Name");

            RuleFor(book => book.Description)
                .NotEmpty()
                .WithMessage("Can`t have a book without Description")
                .MinimumLength(10)
                .WithMessage("The Description can`t lower than 10 character")
                .MaximumLength(200)
                .WithMessage("The Description can`t higher than 200 character");
        }
    }
}