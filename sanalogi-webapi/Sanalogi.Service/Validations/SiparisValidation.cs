using FluentValidation;
using Sanalogi.Data.Dto;
using Sanalogi.Data.Repositories.Abstract;
using System;

namespace Sanalogi.Service.Validations
{
    public class SiparisValidation : AbstractValidator<SiparisDto>
    {
        public SiparisValidation()
        {
            RuleFor(x => x.UrunAdi)
                .NotEmpty().NotNull().WithMessage("Ürün Adı boş bırakılamaz.")
                .MaximumLength(128).WithMessage("Ürün Adı 128 karakterden fazla olamaz.");
            RuleFor(x => x.SiparisVerenFirma)
                .NotEmpty().NotNull().WithMessage("Ürün Adı boş bırakılamaz.")
                .MaximumLength(128).WithMessage("Ürün Adı 128 karakterden fazla olamaz.");
            RuleFor(x => x.Adet)
                .InclusiveBetween(1, int.MaxValue).WithMessage($"Adet sayısı 1 ila {int.MaxValue} arasında olmalıdır.");
            RuleFor(r => r.Tutar)
                .InclusiveBetween(1, decimal.MaxValue).WithMessage($"Tutar 1 ila {decimal.MaxValue} arasında olmalıdır.");
            RuleFor(r => r.SiparisTarihi)
                .LessThan(DateTime.Now).WithMessage("Sipariş tarihi bugünün tarihinden büyük olamaz.");
        }
    }
}
