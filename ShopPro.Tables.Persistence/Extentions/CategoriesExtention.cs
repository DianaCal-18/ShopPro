
namespace ShopPro.Tables.Persistence.Extentions
{
    public static class CategoriesExtention
    {
        public static CategoriesDto ConvertCatEntityToCategoriesDto(this CategoriesEntity categories)
        {
            CategoriesDto categoriesDto = new CategoriesDto()

            {
                categoryid = categories.id,
                categoryname = categories.categoryname,
                description = categories.description,

            };
            return categoriesDto;

        }

        public static CategoriesEntity ConvertCatSaveDtoToCategoriesEntity(this CategoriesSaveDto categoriesSave)
        {
            return new CategoriesEntity

            {
                id = categoriesSave.categoryid,
                categoryname = categoriesSave.categoryname,
                description = categoriesSave.description,
                creation_date = categoriesSave.creation_date,
                creation_user = categoriesSave.creation_user

            };


        }
        public static CategoriesEntity ConvertCatRemoveDtoToCategoriesEntity(this CategoriesRemoveDto categoriesRemove)
        {
            return new CategoriesEntity
            {
                id = categoriesRemove.categoryid,
                categoryname = categoriesRemove.categoryname,
                description = categoriesRemove.description,
                delete_user = categoriesRemove.delete_user,
                deleted = categoriesRemove.deleted,
                delete_date = categoriesRemove.delete_date,

            };
        }
        
        public static void ConvertCatEntityToCategoriesUpdateDto(this CategoriesEntity categories, CategoriesUpdateDto categoriesUpdateDto)
        {
            {
                categories.id = categoriesUpdateDto.categoryid;
                categories.categoryname = categoriesUpdateDto.categoryname;
                categories.description = categoriesUpdateDto.description;
                categories.modify_date = categoriesUpdateDto.modify_date;
                categories.modify_user = categoriesUpdateDto.modify_user;

            };


        }


    }
}
