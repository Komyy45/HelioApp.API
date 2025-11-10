using FluentValidation;
using HelioApp.Application.DTOs.Common;

namespace HelioApp.API.Validators;

internal sealed class PaginationRequestValidator : AbstractValidator<PaginationRequest>
{
    private readonly int[] _allowedValues = [5, 10, 15, 20, 30];
    
    public PaginationRequestValidator()
    {
        RuleFor(p => p.Size)
            .Must(size => _allowedValues.Contains(size));
    }
}