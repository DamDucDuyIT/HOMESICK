using Homesick.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homesick.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
              .GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            if (context.Foods.Any())
            {
                return;
            }

            Food goiCuon = new Food {
                FoodName = "Gỏi cuốn",
                FoodPrice = 20.000M,
                FoodUnit = "4 gỏi",
                FoodAvatar="goicuon.jpg",
                FoodInfo = "Gỏi cuốn bao gồm nhiều thành phần: bánh tráng dẻo, tôm sú hoặc tôm đất,thịt ba chỉ, gia vị (tỏi, muối đường), bún tươi, giá sống, xà lách, rau thơm, hẹlá. Các nguyên liệu thịt, tôm thường được dùng phương pháp luộc và hấp để làm chín."
            };
            Food banhTrangTron = new Food
            {
                FoodName = "Bánh tráng trộn",
                FoodPrice = 10.000M,
                FoodUnit = "1 hộp",
                FoodAvatar = "banhtrangtron.jpg",
                FoodInfo = " những nguyên liệu chính là bánh tráng phơi sương cắt sợi dài vừa ăn, mắm tôm, ruốc, trứng cút, khô bò, khô mực, xoài bào nhuyễn, rau răm, sa tế."
            };
            Food bapXao = new Food
            {
                FoodName = "Bắp xào",
                FoodPrice = 10.000M,
                FoodUnit = "1 hộp",
                FoodAvatar = "bapxao.jpg",
                FoodInfo = "Bắp xào chỉ là bắp nếp hay hạt bắp mỹ xào với bơ, ruốc tôm và hành lá, một số nơi bán có thêm hành phi, lạp xưởng... "
            };
            Food botChien = new Food
            {
                FoodName = "Bột chiên",
                FoodPrice = 15.000M,
                FoodUnit = "1 dĩa",
                FoodAvatar = "botchien.jpg",
                FoodInfo = "Bột chiên thật ra rất đơn giản, chỉ là những khối bột gạo được xắt vuông vừa ăn, xóc qua hắc xì dầu, nước tương, chiên trên chảo cho vàng giòn mặt ngoài, nóng bên trong, cùng với trứng, hành lá."
            };
            Food goiKhoBo = new Food
            {
                FoodName = "Gỏi khô bò",
                FoodPrice = 10.000M,
                FoodUnit = "1 dĩa",
                FoodAvatar = "goikhobo.jpg",
                FoodInfo = "Sợi đu đủ bào nhuyễn thấm nước xốt bò, bên trên là những miếng khô bò dai mềm, đậu phộng, rau thơm thái nhuyễn, bánh phồng tôm. Khi ăn cho thêm tương ớt hay sa tế. Thịt bò khô dai dai, sần sật, vị mặn đậm đà nước sốt bò, vị ngọt của đu đủ hòa cùng vị ớt cay nồng kích thích vị giác, ăn hoài không thấy ngán."
            };

            context.Foods.AddRange(goiCuon, bapXao, banhTrangTron, botChien, goiKhoBo);
            context.SaveChanges();

            Chef chef1 = new Chef
            {
                ChefName = "Nguyễn Thị Hà",
                ChefCareer = "Nội trợ",
                ChefAddress = "Bình Dương, Việt Nam",
                ChefDisplayName = "Thím Hà",
                ChefPhone = "0999999999",
                ChefInfo = "nấu ăn với cả niềm đam mê",
                ChefAvatar = "1.png",
                Foods = new List<Food> {goiCuon,bapXao},
            };
            Chef chef2 = new Chef
            {
                ChefName = "Trần Văn Nam",
                ChefCareer = "Sửa xe",
                ChefAddress = "Sài gòn, Việt Nam",
                ChefDisplayName = "Anh Ba 247",
                ChefPhone = "0999999998",
                ChefInfo = "tuyệt đối an toàn, thơn ngon, giá cả cạnh tranh",
                ChefAvatar = "2.png",
                Foods = new List<Food> { banhTrangTron},
            };
            Chef chef3 = new Chef
            {
                ChefName = "Lê Thị Trang",
                ChefCareer = "Nhân viên bán thời gian",
                ChefAddress = "Sài gòn, Việt Nam",
                ChefDisplayName = "Hana",
                ChefPhone = "0999999997",
                ChefInfo = "đa dạng món ăn, giao hàng nhanh chóng, chất lượng tuyệt vời",
                ChefAvatar = "3.png",
                Foods = new List<Food> { botChien, goiKhoBo },
            };
            context.Chefs.AddRange(chef1, chef2, chef3,chef1,chef2,chef3);
            context.SaveChanges();

            Customer customer1 = new Customer
            {
                CustomerName = "Nguyễn Văn Anh",
                CustomerDisplayName = "Hero123",
                CustomerAddress = "Ngã 6, Bình Dương",
                CustomerPhone = "0123456789",
                CustomerInfo = "sinh viên IT"
            };
            Customer customer2 = new Customer
            {
                CustomerName = "Nguyễn Thị Phương",
                CustomerDisplayName = "PhươngCute",
                CustomerAddress = "Net area, Tp.Thủ Dầu Một",
                CustomerPhone = "0909111444",
                CustomerInfo = "quản lý quán net"
            };
            Customer customer3 = new Customer
            {
                CustomerName = "Phương Trúc Anh",
                CustomerDisplayName = "Thomy",
                CustomerAddress = "C44, quận Tân Bình",
                CustomerPhone = "087541563",
                CustomerInfo = "Trông trẻ"
            };
            context.AddRange(customer1,customer2,customer3);
            context.SaveChanges();

        }
    }
}
