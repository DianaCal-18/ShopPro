
namespace ShopPro.Tables.Persistence.Extentions
{
    public static class ShippersExtention
    {
        /*  public static ShippersDto ConvertShipEntityToShippersDto(this ShippersEntity shippers)
        {
            ShippersDto shippersDto = new ShippersDto()
            {
                shipperid = shippers.id,
                companyname = shippers.companyname,
                phone = shippers.phone

            };
            return shippersDto;

        }

        public static ShippersEntity ConvertShipDtoToShippersEntity(this ShippersEntity shippers)
        {
            return new ShippersEntity

            {

                id = shippers.id,
                companyname = shippers.companyname,
                phone = shippers.phone

            };


        }

        public static void ConvertShipEntityToShipperUpdate(this ShippersEntity shippers, ShippersDto shippersDto)
        {
            {
                shippers.id = shippersDto.shipperid;
                shippers.phone = shippersDto.phone;
                shippers.companyname = shippersDto.companyname;


            };


        }
    }
}
