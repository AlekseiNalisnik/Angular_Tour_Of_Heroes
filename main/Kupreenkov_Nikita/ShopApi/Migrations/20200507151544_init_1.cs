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
                keyValues: new object[] { new Guid("c109e4d8-cb8d-4129-93ef-6ea5b179f379"), new Guid("1eb7449f-ca12-4597-a5f4-389dd2022970") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("e72da63c-c66c-4816-b7b0-4ff2a27e9420"), new Guid("4868d71a-1e87-4e66-b9d9-e72f0b34539f") });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: new Guid("60ecc6bb-1c64-43f3-b25f-7d64d2353c71"));

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: new Guid("d1febcc1-5254-49f9-bdcc-38cc8936673a"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("0a84f60a-23aa-4997-872b-df11eabf09da"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("3c403680-85c5-48fe-93b3-15d046c30398"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("5132ebcc-f71c-4728-858c-697a7bc96c7c"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("7d281129-d54c-47d6-ac1d-b7a37f23ca2e"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("d34809e3-a7cf-4d7c-811c-71476a9de513"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1eb7449f-ca12-4597-a5f4-389dd2022970"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4868d71a-1e87-4e66-b9d9-e72f0b34539f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e72da63c-c66c-4816-b7b0-4ff2a27e9420"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("20946df9-371a-424f-8b90-3e39838f37e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceed41a9-19c3-46c2-8892-a781cb07dac8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c109e4d8-cb8d-4129-93ef-6ea5b179f379"));

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
                    { new Guid("c6a35b42-33bd-4fc9-bfc6-218167ab0a60"), "6f176562-03ec-445a-ac9b-0c160ed1d8a1", "Admin", "ADMIN" },
                    { new Guid("4bdd8ffc-5a83-48c2-8943-629d36cbad76"), "2a92e381-dbc3-4df3-8dce-2001ffd26b50", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6ee79361-7393-44be-8cfe-a0953e992ca4"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "06bd48ec-4077-40ab-826f-bbc8de5a7a2d", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEEAaCZHHRu0AsZizh9uWymzBb88U5XWFjPWwp3Yursv4dFRpbzQ1L+V8icjLbFNKRA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("0b1fc6c8-0308-4d97-9505-bfc1279284a2"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "e5f46540-d48e-46d2-95b2-eb89d515cfe2", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEIs5tLC6yhDpZ60YPdAuve9M4rnKo6qV1DXseB8Q4+icahcLxGcSLTdun6tS2m5ipg==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("93115cc0-c0fb-46be-a589-fb7c55cd39a5"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("6ee79361-7393-44be-8cfe-a0953e992ca4"), new Guid("c6a35b42-33bd-4fc9-bfc6-218167ab0a60") },
                    { new Guid("0b1fc6c8-0308-4d97-9505-bfc1279284a2"), new Guid("4bdd8ffc-5a83-48c2-8943-629d36cbad76") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("5471c99a-e471-4859-9d08-5735ec693a6c"), 300.0, null, new Guid("0b1fc6c8-0308-4d97-9505-bfc1279284a2") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("79f0db66-222f-46a0-86fc-2af94886b56a"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("93115cc0-c0fb-46be-a589-fb7c55cd39a5") },
                    { new Guid("02ac7bb5-db43-4e46-9f0a-78628aee644a"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("93115cc0-c0fb-46be-a589-fb7c55cd39a5") },
                    { new Guid("e0af49ec-f393-41cb-9e40-fa8574cfb9f9"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4") },
                    { new Guid("545da76c-1e3f-4a6b-a755-7dabdac473fd"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4") },
                    { new Guid("ab49a3ae-1c28-4166-8b41-6cd24b0055bf"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("42e08f80-2f26-4543-9f4c-80432489ca1b"), new Guid("5471c99a-e471-4859-9d08-5735ec693a6c"), 3L, new Guid("93115cc0-c0fb-46be-a589-fb7c55cd39a5") },
                    { new Guid("78f59bab-4ef3-43b4-acfc-ba7106519336"), new Guid("5471c99a-e471-4859-9d08-5735ec693a6c"), 0L, new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4") }
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
                keyValues: new object[] { new Guid("0b1fc6c8-0308-4d97-9505-bfc1279284a2"), new Guid("4bdd8ffc-5a83-48c2-8943-629d36cbad76") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("6ee79361-7393-44be-8cfe-a0953e992ca4"), new Guid("c6a35b42-33bd-4fc9-bfc6-218167ab0a60") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("42e08f80-2f26-4543-9f4c-80432489ca1b"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("78f59bab-4ef3-43b4-acfc-ba7106519336"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("02ac7bb5-db43-4e46-9f0a-78628aee644a"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("545da76c-1e3f-4a6b-a755-7dabdac473fd"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("79f0db66-222f-46a0-86fc-2af94886b56a"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ab49a3ae-1c28-4166-8b41-6cd24b0055bf"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("e0af49ec-f393-41cb-9e40-fa8574cfb9f9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4bdd8ffc-5a83-48c2-8943-629d36cbad76"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6a35b42-33bd-4fc9-bfc6-218167ab0a60"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6ee79361-7393-44be-8cfe-a0953e992ca4"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("5471c99a-e471-4859-9d08-5735ec693a6c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54ec7ebd-9a11-49ad-9c61-ca094bfd34d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93115cc0-c0fb-46be-a589-fb7c55cd39a5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b1fc6c8-0308-4d97-9505-bfc1279284a2"));

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
                    { new Guid("4868d71a-1e87-4e66-b9d9-e72f0b34539f"), "61935070-e969-4bfd-9d17-2427ad7f3a0d", "Admin", "ADMIN" },
                    { new Guid("1eb7449f-ca12-4597-a5f4-389dd2022970"), "cfa310bc-db9b-4af1-adb0-2ebb9a52669f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e72da63c-c66c-4816-b7b0-4ff2a27e9420"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "b3a1c058-c57e-4a9c-b3f3-ba948282b41b", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEPQSH1TPozbaAsS9/T4kQy6MLn4wjoA+WiiDOI2Gpgi5ShDLKb3Vy1Yx2nAxxWcwQA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("c109e4d8-cb8d-4129-93ef-6ea5b179f379"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "c2c54161-74b0-4da0-8337-2a8558bcb714", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEP2ZOwy8gS0BWSRjDnfnkioq+Cwyx77KdmQShAQgb3T0HX+FKpxHl6cNZPfvDxbjEw==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("ceed41a9-19c3-46c2-8892-a781cb07dac8"), "Holy bear", "Bear", 0.0, 1.0 },
                    { new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("e72da63c-c66c-4816-b7b0-4ff2a27e9420"), new Guid("4868d71a-1e87-4e66-b9d9-e72f0b34539f") },
                    { new Guid("c109e4d8-cb8d-4129-93ef-6ea5b179f379"), new Guid("1eb7449f-ca12-4597-a5f4-389dd2022970") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "Cost", "OrderId", "UserId" },
                values: new object[] { new Guid("20946df9-371a-424f-8b90-3e39838f37e6"), 300.0, null, new Guid("c109e4d8-cb8d-4129-93ef-6ea5b179f379") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("d34809e3-a7cf-4d7c-811c-71476a9de513"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsbear.jpeg", new Guid("ceed41a9-19c3-46c2-8892-a781cb07dac8") },
                    { new Guid("3c403680-85c5-48fe-93b3-15d046c30398"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsduck.jpeg", new Guid("ceed41a9-19c3-46c2-8892-a781cb07dac8") },
                    { new Guid("5132ebcc-f71c-4728-858c-697a7bc96c7c"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetshi_duck.jpeg", new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc") },
                    { new Guid("0a84f60a-23aa-4997-872b-df11eabf09da"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetsinjure.jpeg", new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc") },
                    { new Guid("7d281129-d54c-47d6-ac1d-b7a37f23ca2e"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assetspzduck.jpeg", new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc") }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("d1febcc1-5254-49f9-bdcc-38cc8936673a"), new Guid("20946df9-371a-424f-8b90-3e39838f37e6"), 3L, new Guid("ceed41a9-19c3-46c2-8892-a781cb07dac8") },
                    { new Guid("60ecc6bb-1c64-43f3-b25f-7d64d2353c71"), new Guid("20946df9-371a-424f-8b90-3e39838f37e6"), 0L, new Guid("1593879a-da4e-439f-827e-6792b0e1a6bc") }
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
