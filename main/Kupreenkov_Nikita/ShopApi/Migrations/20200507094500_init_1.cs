using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("680a7da8-c86c-4d5b-8b5b-7e7730f46fd4"), new Guid("b8fffa5a-5ea2-4089-9a2f-a74efaa481fc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a52a0dee-a466-40ce-a65f-49a97b837d7e"), new Guid("2e0e803c-2190-40d2-a601-a8b307ae4383") });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: new Guid("881e2316-b231-4dab-a916-7d66038213f7"));

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: new Guid("d9480825-4827-4fb1-a65a-c16668ee837e"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("144cf588-d1e9-4a46-81ab-815da4c54fd8"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("49bef3f4-eabe-4076-a80f-9136c98364c9"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("66472895-608b-4569-9975-8e9f09d0d33d"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("965167e8-bf19-4a03-bbdb-2386ab8d296d"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ee032047-47c3-4b9c-8635-84ed4ff52175"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e0e803c-2190-40d2-a601-a8b307ae4383"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b8fffa5a-5ea2-4089-9a2f-a74efaa481fc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a52a0dee-a466-40ce-a65f-49a97b837d7e"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("b3b5b0e7-bf74-453a-8e24-f9f9f7c42b91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c31769d-20fd-463e-8615-385ff24acb4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680a7da8-c86c-4d5b-8b5b-7e7730f46fd4"));

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("066bf58c-284d-4748-ad20-296000d69604"), "313784c9-8f76-46c0-b258-692cd3b39f29", "Admin", "ADMIN" },
                    { new Guid("f4fcdb8c-c50b-4ab0-8a4b-fc6d875e5f82"), "b1de71c7-c4d0-4263-b6f5-459ef25d4571", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9f9f6b62-47a9-485a-a800-25e58c2b34f2"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "91e144e8-c671-430f-8fcb-51a44a001c6e", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEJoY/qvKE9gLAQ/LSKEI4ghEVE5wZkgCxYkWa/MNPmnuLBE6tJAV20g1l3QR77OrIQ==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("6c33a5ad-c01f-44f3-914e-ff0ab3f64dbb"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "b4f85e46-de46-472c-8625-bcf936784402", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEEFZ+3bB5gRyLc3G88hQ52MvOzjBaFC12Vs0Ugi08n9zPY2ZUnyzM2N/P6pYwPFN4g==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("51cbdc41-6ac6-4c71-9b8e-cbc7ace01669"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("9f9f6b62-47a9-485a-a800-25e58c2b34f2"), new Guid("066bf58c-284d-4748-ad20-296000d69604") },
                    { new Guid("6c33a5ad-c01f-44f3-914e-ff0ab3f64dbb"), new Guid("f4fcdb8c-c50b-4ab0-8a4b-fc6d875e5f82") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("5606f662-6518-44a6-af10-d59d349d99c3"), 300.0, null, new Guid("6c33a5ad-c01f-44f3-914e-ff0ab3f64dbb") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("643bbd42-2c94-4132-a21a-84e3211a1f85"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("51cbdc41-6ac6-4c71-9b8e-cbc7ace01669") },
                    { new Guid("43fc2b67-7eee-4095-b90d-fb25295cbe98"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("51cbdc41-6ac6-4c71-9b8e-cbc7ace01669") },
                    { new Guid("67bc843e-f5db-447f-b8cc-e3b276b96a54"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a") },
                    { new Guid("6eaf8a3a-6c70-46d7-b83a-e0730cc07bfa"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a") },
                    { new Guid("82118d00-5a47-4ba6-8230-07d5c4c4cb9c"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("e068b609-be21-4a52-9acb-b278e1fc064d"), new Guid("5606f662-6518-44a6-af10-d59d349d99c3"), 3L, new Guid("51cbdc41-6ac6-4c71-9b8e-cbc7ace01669") },
                    { new Guid("6ea64505-fb9b-4e83-b170-7f3c709e2dc9"), new Guid("5606f662-6518-44a6-af10-d59d349d99c3"), 0L, new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("6c33a5ad-c01f-44f3-914e-ff0ab3f64dbb"), new Guid("f4fcdb8c-c50b-4ab0-8a4b-fc6d875e5f82") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("9f9f6b62-47a9-485a-a800-25e58c2b34f2"), new Guid("066bf58c-284d-4748-ad20-296000d69604") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("6ea64505-fb9b-4e83-b170-7f3c709e2dc9"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("e068b609-be21-4a52-9acb-b278e1fc064d"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("43fc2b67-7eee-4095-b90d-fb25295cbe98"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("643bbd42-2c94-4132-a21a-84e3211a1f85"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("67bc843e-f5db-447f-b8cc-e3b276b96a54"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("6eaf8a3a-6c70-46d7-b83a-e0730cc07bfa"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("82118d00-5a47-4ba6-8230-07d5c4c4cb9c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("066bf58c-284d-4748-ad20-296000d69604"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4fcdb8c-c50b-4ab0-8a4b-fc6d875e5f82"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9f9f6b62-47a9-485a-a800-25e58c2b34f2"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("5606f662-6518-44a6-af10-d59d349d99c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("51cbdc41-6ac6-4c71-9b8e-cbc7ace01669"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e29788f3-3870-4b4f-8641-1f96573e9f7a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6c33a5ad-c01f-44f3-914e-ff0ab3f64dbb"));

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e0e803c-2190-40d2-a601-a8b307ae4383"), "f0d0d137-0cfe-4621-a86f-4a59aba94d48", "Admin", "ADMIN" },
                    { new Guid("b8fffa5a-5ea2-4089-9a2f-a74efaa481fc"), "9fbf8bb0-9275-4789-a820-45b8c2ba1353", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a52a0dee-a466-40ce-a65f-49a97b837d7e"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "d26ece5c-7721-4e23-a42b-434b2e6061e3", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEJr/BqjbmMkLTB0USO5f9lR5MnI4iLZPHWjqnUBCFqNXpAesenUSkx+VKcQhkpfO7Q==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("680a7da8-c86c-4d5b-8b5b-7e7730f46fd4"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "d5e3af42-fb54-422d-b19a-5ec2a1d6de14", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEOiedVU74Z/+IJaGftMnO5Y14BQiml7CvUg5yfEyRvhQh6KSS9uJnPZ3VE+d8n0Ucw==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("7c31769d-20fd-463e-8615-385ff24acb4d"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("a52a0dee-a466-40ce-a65f-49a97b837d7e"), new Guid("2e0e803c-2190-40d2-a601-a8b307ae4383") },
                    { new Guid("680a7da8-c86c-4d5b-8b5b-7e7730f46fd4"), new Guid("b8fffa5a-5ea2-4089-9a2f-a74efaa481fc") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("b3b5b0e7-bf74-453a-8e24-f9f9f7c42b91"), 300.0, null, new Guid("680a7da8-c86c-4d5b-8b5b-7e7730f46fd4") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("49bef3f4-eabe-4076-a80f-9136c98364c9"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("7c31769d-20fd-463e-8615-385ff24acb4d") },
                    { new Guid("144cf588-d1e9-4a46-81ab-815da4c54fd8"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("7c31769d-20fd-463e-8615-385ff24acb4d") },
                    { new Guid("ee032047-47c3-4b9c-8635-84ed4ff52175"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7") },
                    { new Guid("965167e8-bf19-4a03-bbdb-2386ab8d296d"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7") },
                    { new Guid("66472895-608b-4569-9975-8e9f09d0d33d"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7") }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("d9480825-4827-4fb1-a65a-c16668ee837e"), new Guid("b3b5b0e7-bf74-453a-8e24-f9f9f7c42b91"), 3L, new Guid("7c31769d-20fd-463e-8615-385ff24acb4d") },
                    { new Guid("881e2316-b231-4dab-a916-7d66038213f7"), new Guid("b3b5b0e7-bf74-453a-8e24-f9f9f7c42b91"), 0L, new Guid("f6061209-772f-424f-8e2c-ce0f3cc818a7") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
