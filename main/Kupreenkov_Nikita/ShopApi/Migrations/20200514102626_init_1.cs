using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("9e40f1e3-b5ca-4957-ae38-dc904f060b3c"), new Guid("4b3d637b-d28d-450e-bbe0-646e435243b2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("b4d2bec8-4cf5-4c6b-862f-501b298c15bb"), new Guid("cc832a71-e6e9-4238-ac90-073cdba7aa31") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("d4115900-8c4d-4cbd-ba60-92910c973487"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("e3819cae-a628-4ca1-857e-435c96471ca1"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("26dd4048-27f6-4728-a66f-3f506ed80b29"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("2fbf03ca-3a2f-41f2-b09c-86bbf0efcd5b"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("7f10514d-e9b6-4b8a-aa93-618dd8a4b7b2"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("ae10d22b-5298-4868-9230-2383a6dd7630"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("d3119c1c-db38-4901-b7b0-888309e5f20e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4b3d637b-d28d-450e-bbe0-646e435243b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc832a71-e6e9-4238-ac90-073cdba7aa31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d2bec8-4cf5-4c6b-862f-501b298c15bb"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("742a045b-eba5-4bf2-89c8-fbd07f3ffc23"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58af79df-ddd1-42e4-a9e9-e79ddf96c0f6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9e40f1e3-b5ca-4957-ae38-dc904f060b3c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("fdc61c8f-c3f5-4db6-9a0c-9e9ace9792fd"), "88eb4e46-7aba-4f7c-b53d-9fb840b443bf", "Admin", "ADMIN" },
                    { new Guid("0049412f-f2c6-4bd6-b560-dd41402c662c"), "b23e24d1-d831-465b-b06f-bfdc5e3bf410", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("030f9905-5b4d-4451-b291-c44a255b3a43"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "e74bb5c8-014e-48d4-9db8-b1491f32dfe6", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAENI6NcB4m27uYQXsbwUqxqJ0ixnqLPmQVOx2E8+vfLpAC7xt0Prvf/1lJaCPtY8M7g==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("bec869d2-2bc3-42fb-9459-bafc49509a57"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "8df262c1-62ea-4c01-8c56-0fb7cf27d147", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEMrww4KQGV/lv+jKvYHEvk3/kqgd0T41PvAT4rmTOuykxsIU3CYtAeBVQMYgYb4n5Q==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("13302a19-82c5-4e53-a623-7273c2555ac3"), "Holy bear", "Bear", 150.0, 1.0 },
                    { new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("030f9905-5b4d-4451-b291-c44a255b3a43"), new Guid("fdc61c8f-c3f5-4db6-9a0c-9e9ace9792fd") },
                    { new Guid("bec869d2-2bc3-42fb-9459-bafc49509a57"), new Guid("0049412f-f2c6-4bd6-b560-dd41402c662c") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "OrderId", "UserId" },
                values: new object[] { new Guid("1934467a-b607-4004-a58c-f26cd1ccad74"), null, new Guid("bec869d2-2bc3-42fb-9459-bafc49509a57") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("b6f3c375-6343-401d-ac2b-dc5249520862"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/bear.jpeg", new Guid("13302a19-82c5-4e53-a623-7273c2555ac3") },
                    { new Guid("611e4b75-c798-4191-9bb2-9e0e59c00560"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/duck.jpeg", new Guid("13302a19-82c5-4e53-a623-7273c2555ac3") },
                    { new Guid("b43b952a-1425-4ae7-95d7-fc0c8f9a0596"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/hi_duck.jpeg", new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2") },
                    { new Guid("76660492-32b0-4404-a992-97aff9179764"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/injure.jpeg", new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2") },
                    { new Guid("dd5f6823-0055-44d6-88bb-3169d0907381"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/pzduck.jpeg", new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("cd0aa590-a54b-4c3e-b3ac-abae6552c396"), new Guid("1934467a-b607-4004-a58c-f26cd1ccad74"), 3L, new Guid("13302a19-82c5-4e53-a623-7273c2555ac3") },
                    { new Guid("aba48ef1-c87d-46a3-8fd6-9b9fded740cb"), new Guid("1934467a-b607-4004-a58c-f26cd1ccad74"), 1L, new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("030f9905-5b4d-4451-b291-c44a255b3a43"), new Guid("fdc61c8f-c3f5-4db6-9a0c-9e9ace9792fd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("bec869d2-2bc3-42fb-9459-bafc49509a57"), new Guid("0049412f-f2c6-4bd6-b560-dd41402c662c") });

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("aba48ef1-c87d-46a3-8fd6-9b9fded740cb"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("cd0aa590-a54b-4c3e-b3ac-abae6552c396"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("611e4b75-c798-4191-9bb2-9e0e59c00560"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("76660492-32b0-4404-a992-97aff9179764"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b43b952a-1425-4ae7-95d7-fc0c8f9a0596"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("b6f3c375-6343-401d-ac2b-dc5249520862"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("dd5f6823-0055-44d6-88bb-3169d0907381"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0049412f-f2c6-4bd6-b560-dd41402c662c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdc61c8f-c3f5-4db6-9a0c-9e9ace9792fd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("030f9905-5b4d-4451-b291-c44a255b3a43"));

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: new Guid("1934467a-b607-4004-a58c-f26cd1ccad74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13302a19-82c5-4e53-a623-7273c2555ac3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b9102a8-276b-46cc-bfd0-8bcf135ec8c2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bec869d2-2bc3-42fb-9459-bafc49509a57"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cc832a71-e6e9-4238-ac90-073cdba7aa31"), "55c2b6d5-b32b-40a2-8377-8e3c0b45c4e5", "Admin", "ADMIN" },
                    { new Guid("4b3d637b-d28d-450e-bbe0-646e435243b2"), "3b5c7d68-dba3-4fdc-aa77-dfc5b0deeb42", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b4d2bec8-4cf5-4c6b-862f-501b298c15bb"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "0b51fb45-4b4c-489f-ab35-a26d1e152288", "Admin@Admin.com", true, "Master", "Admin", false, null, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAELuWT2X2Y43ajaYVDL87GllrmcbrExgDTXsKLl/6nfvns7gzbFHmoWiWi0wU0V1NPQ==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" },
                    { new Guid("9e40f1e3-b5ca-4957-ae38-dc904f060b3c"), 0, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ae1fca05-f6dc-478a-8cc9-333577a7c799", "User@User.com", true, "Standart", "User", false, null, null, "USER@USER.COM", "STANDARTUSER", "AQAAAAEAACcQAAAAEMWDFd7yNHAFOZ7myfSzGxwGCQFyJREZ0SeneUA6FsmdcDWYZvFBQDkzAi+M+gQQQA==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "standartuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("58af79df-ddd1-42e4-a9e9-e79ddf96c0f6"), "Holy bear", "Bear", 150.0, 1.0 },
                    { new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203"), "Tasty and cute sugar boys", "GammyBear", 10.5, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("b4d2bec8-4cf5-4c6b-862f-501b298c15bb"), new Guid("cc832a71-e6e9-4238-ac90-073cdba7aa31") },
                    { new Guid("9e40f1e3-b5ca-4957-ae38-dc904f060b3c"), new Guid("4b3d637b-d28d-450e-bbe0-646e435243b2") }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "OrderId", "UserId" },
                values: new object[] { new Guid("742a045b-eba5-4bf2-89c8-fbd07f3ffc23"), null, new Guid("9e40f1e3-b5ca-4957-ae38-dc904f060b3c") });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("26dd4048-27f6-4728-a66f-3f506ed80b29"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/bear.jpeg", new Guid("58af79df-ddd1-42e4-a9e9-e79ddf96c0f6") },
                    { new Guid("ae10d22b-5298-4868-9230-2383a6dd7630"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/duck.jpeg", new Guid("58af79df-ddd1-42e4-a9e9-e79ddf96c0f6") },
                    { new Guid("2fbf03ca-3a2f-41f2-b09c-86bbf0efcd5b"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/hi_duck.jpeg", new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203") },
                    { new Guid("d3119c1c-db38-4901-b7b0-888309e5f20e"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/injure.jpeg", new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203") },
                    { new Guid("7f10514d-e9b6-4b8a-aa93-618dd8a4b7b2"), "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets/pzduck.jpeg", new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203") }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("e3819cae-a628-4ca1-857e-435c96471ca1"), new Guid("742a045b-eba5-4bf2-89c8-fbd07f3ffc23"), 3L, new Guid("58af79df-ddd1-42e4-a9e9-e79ddf96c0f6") },
                    { new Guid("d4115900-8c4d-4cbd-ba60-92910c973487"), new Guid("742a045b-eba5-4bf2-89c8-fbd07f3ffc23"), 1L, new Guid("a994c5a8-32e4-40bd-8f9b-8b1a33724203") }
                });
        }
    }
}
