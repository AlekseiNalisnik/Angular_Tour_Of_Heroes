using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("6a5e287a-5ce3-42db-bb63-bd07aab07c75"), new Guid("608c865e-afa0-478e-ad6d-e693e4e1c96f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c49f7984-8f01-4867-8f57-78e754bd4d5f"), new Guid("be709a7b-d4b0-4734-a1b1-95062a7f400d") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("08be649f-9b4c-4f30-b33b-2a74ff4ab60d"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("572085b5-bd40-4cea-bb4c-f1bafadaceb7"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("69131b73-6ad0-4644-bef6-be7fb1ff22b7"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("8cce048f-330e-48c0-90ab-f1376122aa38"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("900deb1c-2756-456f-8813-8804e421d5bc"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ee25d71b-9095-4d48-a1f3-4f5cb0ce39c9"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("fd6fa37a-4c23-4760-bb22-85a611cc61e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("608c865e-afa0-478e-ad6d-e693e4e1c96f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be709a7b-d4b0-4734-a1b1-95062a7f400d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c49f7984-8f01-4867-8f57-78e754bd4d5f"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("4e58d10a-1029-4504-b541-917b37595175"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c6d141c-d2aa-497c-9b83-a79113324416"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a705246-6186-449c-8bee-dca177df5632"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a5e287a-5ce3-42db-bb63-bd07aab07c75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5fc4cb4e-f835-442c-932c-c7d3a69f7a5b"), "9a845988-9ff2-450f-96a9-cd66df14aab7", "Admin", "ADMIN" },
                    { new Guid("0f8c1f3b-3ae5-46d5-8710-dd3a82670509"), "17fc1fa1-ada0-4216-8155-dc2290ec137e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3b1ae86b-b5a9-412a-9732-179f856f530d"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "961a10c0-99b7-4475-bbaf-9d5a609cfc9b", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEKlw3tEQvtkZhYCwoSvMU5ueoraBFOS2WgNuKjHJpR7Rwge7CvuYVXVTQpIC1pgTlQ==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("42789ce1-1c12-42ad-a23e-53f2099cc73d"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "af3eaecf-bc78-436b-b1e9-7e66aa9c9d5d", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEJLcQXHPD8RoPzG/3ebAFQs4+KqWfmsbgdWcMA5p5vncUBTIm+EFdyy92iZTd/YbaA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("7fcd293a-3f7e-4542-814f-592932f62f04"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3b1ae86b-b5a9-412a-9732-179f856f530d"), new Guid("5fc4cb4e-f835-442c-932c-c7d3a69f7a5b") },
                    { new Guid("42789ce1-1c12-42ad-a23e-53f2099cc73d"), new Guid("0f8c1f3b-3ae5-46d5-8710-dd3a82670509") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("6212c8bf-3380-425e-916b-dbe01b1db613"), 300.0, null, new Guid("42789ce1-1c12-42ad-a23e-53f2099cc73d") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("6187a6f6-bf9f-45bc-8cd8-0716a19e52f9"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("7fcd293a-3f7e-4542-814f-592932f62f04") },
                    { new Guid("7ea877c3-8578-4a6e-9b8e-7f8a37b8cd84"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("7fcd293a-3f7e-4542-814f-592932f62f04") },
                    { new Guid("bca5baee-8dde-4cfa-8481-98de68676cf8"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6") },
                    { new Guid("37b09b5c-e497-4b2e-bd25-742ff95b8593"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6") },
                    { new Guid("cdddc232-bb3a-4269-b3e5-8b404fc9c5f6"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("831c3943-2832-4b94-bbe0-6419c48535bf"), new Guid("6212c8bf-3380-425e-916b-dbe01b1db613"), 3L, new Guid("7fcd293a-3f7e-4542-814f-592932f62f04") },
                    { new Guid("07e1fde8-792b-49ab-8d49-60e2c94b5e1b"), new Guid("6212c8bf-3380-425e-916b-dbe01b1db613"), 0L, new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3b1ae86b-b5a9-412a-9732-179f856f530d"), new Guid("5fc4cb4e-f835-442c-932c-c7d3a69f7a5b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("42789ce1-1c12-42ad-a23e-53f2099cc73d"), new Guid("0f8c1f3b-3ae5-46d5-8710-dd3a82670509") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("07e1fde8-792b-49ab-8d49-60e2c94b5e1b"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("831c3943-2832-4b94-bbe0-6419c48535bf"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("37b09b5c-e497-4b2e-bd25-742ff95b8593"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("6187a6f6-bf9f-45bc-8cd8-0716a19e52f9"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("7ea877c3-8578-4a6e-9b8e-7f8a37b8cd84"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("bca5baee-8dde-4cfa-8481-98de68676cf8"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("cdddc232-bb3a-4269-b3e5-8b404fc9c5f6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f8c1f3b-3ae5-46d5-8710-dd3a82670509"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fc4cb4e-f835-442c-932c-c7d3a69f7a5b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3b1ae86b-b5a9-412a-9732-179f856f530d"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("6212c8bf-3380-425e-916b-dbe01b1db613"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7fcd293a-3f7e-4542-814f-592932f62f04"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a7c5f92d-d650-4291-83c2-9f4823017cb6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42789ce1-1c12-42ad-a23e-53f2099cc73d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("be709a7b-d4b0-4734-a1b1-95062a7f400d"), "c20afc0f-a9cf-41da-a5ca-46152a894af2", "Admin", "ADMIN" },
                    { new Guid("608c865e-afa0-478e-ad6d-e693e4e1c96f"), "2deed078-cdba-4005-a2f9-562a6dd1741e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c49f7984-8f01-4867-8f57-78e754bd4d5f"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "451c119b-c066-40b3-8d3e-d6bc2b5f00c2", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEPMbVS017XGsrAVzPw3cnCvrMVyI1kfpJH19Qkg36hZrkT46HqAfTS51hQR7D7+JHQ==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("6a5e287a-5ce3-42db-bb63-bd07aab07c75"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "b810bf02-58d6-4932-8643-77176f4cfb07", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAELT167HEmxi8dQWtDT+d3+cXzujwp0ztN9JW2vrjAlFBDf4P6+oEczgJeuZEXx0SjA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("4c6d141c-d2aa-497c-9b83-a79113324416"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("8a705246-6186-449c-8bee-dca177df5632"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("c49f7984-8f01-4867-8f57-78e754bd4d5f"), new Guid("be709a7b-d4b0-4734-a1b1-95062a7f400d") },
                    { new Guid("6a5e287a-5ce3-42db-bb63-bd07aab07c75"), new Guid("608c865e-afa0-478e-ad6d-e693e4e1c96f") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("4e58d10a-1029-4504-b541-917b37595175"), 300.0, null, new Guid("6a5e287a-5ce3-42db-bb63-bd07aab07c75") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("fd6fa37a-4c23-4760-bb22-85a611cc61e2"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("4c6d141c-d2aa-497c-9b83-a79113324416") },
                    { new Guid("8cce048f-330e-48c0-90ab-f1376122aa38"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("4c6d141c-d2aa-497c-9b83-a79113324416") },
                    { new Guid("900deb1c-2756-456f-8813-8804e421d5bc"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("8a705246-6186-449c-8bee-dca177df5632") },
                    { new Guid("ee25d71b-9095-4d48-a1f3-4f5cb0ce39c9"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("8a705246-6186-449c-8bee-dca177df5632") },
                    { new Guid("69131b73-6ad0-4644-bef6-be7fb1ff22b7"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("8a705246-6186-449c-8bee-dca177df5632") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("572085b5-bd40-4cea-bb4c-f1bafadaceb7"), new Guid("4e58d10a-1029-4504-b541-917b37595175"), 3L, new Guid("4c6d141c-d2aa-497c-9b83-a79113324416") },
                    { new Guid("08be649f-9b4c-4f30-b33b-2a74ff4ab60d"), new Guid("4e58d10a-1029-4504-b541-917b37595175"), 0L, new Guid("8a705246-6186-449c-8bee-dca177df5632") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
