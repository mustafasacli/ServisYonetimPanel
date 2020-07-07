namespace ServisYonetimPanel.Business.Generic
{
    using ServisYonetimPanel.Entity;
    using SimpleInfra.Validation;
    using System;
    using System.Linq;

    public abstract class BaseGenericBusiness
    {
        protected void SetCreationValues(BaseEntity entity, long createdBy = 1)
        {
            entity.CreatedOn = DateTime.Now;
            entity.CreatedOnUnixTimestamp = entity.CreatedOn.Ticks;
            entity.CreatedBy = createdBy;

            entity.UpdatedBy = null;
            entity.UpdatedOn = null;
            entity.UpdatedOnUnixTimestamp = null;

            entity.IsActive = true;
        }

        protected void SetUpdateValues(BaseEntity entity, long updatedBy = 1, bool isDelete = false)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedOnUnixTimestamp = entity.UpdatedOn.Value.Ticks;
            entity.UpdatedBy = updatedBy;

            entity.IsActive = !isDelete;
        }

        protected string GetValidationErrors(EntityValidationResult validationResult)
        {
            if (validationResult == null)
                return string.Empty;

            if (!validationResult.HasError)
                return string.Empty;

            return string.Join(Environment.NewLine, validationResult.Errors.Select(q => q.ErrorMessage).ToArray());
        }
    }
}