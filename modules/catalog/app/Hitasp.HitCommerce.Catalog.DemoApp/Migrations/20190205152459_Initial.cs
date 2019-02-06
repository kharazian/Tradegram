using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hitasp.HitCommerce.Catalog.DemoApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpClaimTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    Regex = table.Column<string>(maxLength: 512, nullable: true),
                    RegexDescription = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogBackInStockSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBackInStockSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProductAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_StockQuantityHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    QuantityAdjustment = table.Column<int>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    CombinationId = table.Column<Guid>(nullable: true),
                    WarehouseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_StockQuantityHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProductTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UsageCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProductTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogSpecificationAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogSpecificationAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogViewTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ViewPath = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogViewTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 196, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => new { x.UserId, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogPredefinedAttributeValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    PriceAdjustment = table.Column<decimal>(nullable: false),
                    PriceAdjustmentUsePercentage = table.Column<bool>(nullable: false),
                    WeightAdjustment = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    IsPreSelected = table.Column<bool>(nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    ProductAttributeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogPredefinedAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogPredefinedAttributeValues_CatalogProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "CatalogProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogPredefinedAttributeValues_CatalogProductAttributes_ProductAttributeId1",
                        column: x => x.ProductAttributeId1,
                        principalTable: "CatalogProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogSpecificationAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecificationAttributeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ColorSquaresRgb = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    SpecificationAttributeId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogSpecificationAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogSpecificationAttributeOptions_CatalogSpecificationAttributes_SpecificationAttributeId",
                        column: x => x.SpecificationAttributeId,
                        principalTable: "CatalogSpecificationAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogSpecificationAttributeOptions_CatalogSpecificationAttributes_SpecificationAttributeId1",
                        column: x => x.SpecificationAttributeId1,
                        principalTable: "CatalogSpecificationAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    CategoryTemplateId = table.Column<Guid>(nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 450, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 450, nullable: true),
                    MetaTitle = table.Column<string>(maxLength: 150, nullable: true),
                    ParentCategoryId = table.Column<Guid>(nullable: true),
                    PictureId = table.Column<Guid>(nullable: true),
                    PageSize = table.Column<int>(nullable: false),
                    AllowCustomersToSelectPageSize = table.Column<bool>(nullable: false, defaultValue: true),
                    PageSizeOptions = table.Column<string>(nullable: true),
                    PriceRanges = table.Column<string>(nullable: true),
                    ShowOnHomePage = table.Column<bool>(nullable: false, defaultValue: false),
                    IncludeInTopMenu = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogCategories_CatalogViewTemplates_CategoryTemplateId",
                        column: x => x.CategoryTemplateId,
                        principalTable: "CatalogViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogCategories_CatalogCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "CatalogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    ManufacturerTemplateId = table.Column<Guid>(nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 450, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 450, nullable: true),
                    MetaTitle = table.Column<string>(maxLength: 150, nullable: true),
                    PictureId = table.Column<Guid>(nullable: true),
                    PageSize = table.Column<int>(nullable: false),
                    AllowCustomersToSelectPageSize = table.Column<bool>(nullable: false, defaultValue: true),
                    PageSizeOptions = table.Column<string>(nullable: true),
                    PriceRanges = table.Column<string>(nullable: true),
                    ShowOnHomePage = table.Column<bool>(nullable: false, defaultValue: false),
                    Published = table.Column<bool>(nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogManufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogManufacturers_CatalogViewTemplates_ManufacturerTemplateId",
                        column: x => x.ManufacturerTemplateId,
                        principalTable: "CatalogViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductType = table.Column<string>(maxLength: 20, nullable: false),
                    ProductTemplateId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 150, nullable: false),
                    FullDescription = table.Column<string>(maxLength: 450, nullable: true),
                    Code = table.Column<string>(maxLength: 150, nullable: false),
                    Gtin = table.Column<string>(maxLength: 150, nullable: true),
                    ManufacturerPartNumber = table.Column<string>(maxLength: 150, nullable: true),
                    ShowOnHomePage = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    RatingAverage = table.Column<double>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false),
                    AvailableStartDate = table.Column<DateTime>(nullable: true),
                    AvailableEndDate = table.Column<DateTime>(nullable: true),
                    MarkAsNew = table.Column<bool>(nullable: false),
                    MarkAsNewStartDate = table.Column<DateTime>(nullable: true),
                    MarkAsNewEndDate = table.Column<DateTime>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    BasePriceEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    HasDiscountsApplied = table.Column<bool>(nullable: false),
                    VendorId = table.Column<Guid>(nullable: true),
                    MetaKeywords = table.Column<string>(maxLength: 450, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 450, nullable: true),
                    MetaTitle = table.Column<string>(maxLength: 150, nullable: true),
                    DownloadId = table.Column<Guid>(nullable: true),
                    UnlimitedDownloads = table.Column<bool>(nullable: true),
                    MaxNumberOfDownloads = table.Column<int>(nullable: true),
                    DownloadExpirationDays = table.Column<int>(nullable: true),
                    DownloadActivationTypeId = table.Column<int>(nullable: true),
                    HasSampleDownload = table.Column<bool>(nullable: true),
                    SampleDownloadId = table.Column<Guid>(nullable: true),
                    IsGiftCard = table.Column<bool>(nullable: true),
                    GiftCardTypeId = table.Column<int>(nullable: true),
                    Downloadable_OverriddenGiftCardAmount = table.Column<decimal>(nullable: true),
                    HasUserAgreement = table.Column<bool>(nullable: true),
                    UserAgreementText = table.Column<string>(nullable: true),
                    OverriddenGiftCardAmount = table.Column<decimal>(nullable: true),
                    IsShipEnabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogProducts_CatalogViewTemplates_ProductTemplateId",
                        column: x => x.ProductTemplateId,
                        principalTable: "CatalogViewTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogCategories_CategoryDiscount",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: false),
                    CategoryId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogCategories_CategoryDiscount", x => new { x.CategoryId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_CatalogCategories_CategoryDiscount_CatalogCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CatalogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogCategories_CategoryDiscount_CatalogCategories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "CatalogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogManufacturers_ManufacturerDiscount",
                columns: table => new
                {
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: false),
                    ManufacturerId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogManufacturers_ManufacturerDiscount", x => new { x.ManufacturerId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_CatalogManufacturers_ManufacturerDiscount_CatalogManufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "CatalogManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogManufacturers_ManufacturerDiscount_CatalogManufacturers_ManufacturerId1",
                        column: x => x.ManufacturerId1,
                        principalTable: "CatalogManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct_BasePrice",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    BasePriceAmount = table.Column<decimal>(nullable: false),
                    BasePriceUnitId = table.Column<int>(nullable: false),
                    BasePriceBaseAmount = table.Column<decimal>(nullable: false),
                    BasePriceBaseUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct_BasePrice", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_BasePrice_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct_Inventory",
                columns: table => new
                {
                    ShippableId = table.Column<Guid>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<Guid>(nullable: true),
                    UseMultipleWarehouses = table.Column<bool>(nullable: false),
                    DisplayStockAvailability = table.Column<bool>(nullable: false),
                    DisplayStockQuantity = table.Column<bool>(nullable: false),
                    MinStockQuantity = table.Column<int>(nullable: false),
                    AllowBackInStockSubscriptions = table.Column<bool>(nullable: false),
                    OrderMinimumQuantity = table.Column<int>(nullable: false),
                    OrderMaximumQuantity = table.Column<int>(nullable: false),
                    AllowedQuantities = table.Column<string>(nullable: true),
                    NotReturnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct_Inventory", x => x.ShippableId);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Inventory_CatalogProducts_ShippableId",
                        column: x => x.ShippableId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct_Pricing",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    OldPrice = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ProductCost = table.Column<decimal>(nullable: false),
                    DisableBuyButton = table.Column<bool>(nullable: false),
                    DisableWishListButton = table.Column<bool>(nullable: false),
                    CallForPrice = table.Column<bool>(nullable: false),
                    AvailableForPreOrder = table.Column<bool>(nullable: false),
                    PreOrderAvailabilityStartDate = table.Column<DateTime>(nullable: true),
                    CustomerEntersPrice = table.Column<bool>(nullable: false),
                    MinimumCustomerEnteredPrice = table.Column<decimal>(nullable: false),
                    MaximumCustomerEnteredPrice = table.Column<decimal>(nullable: false),
                    IsRental = table.Column<bool>(nullable: false),
                    RentalPriceLength = table.Column<int>(nullable: false),
                    RentalPricePeriodId = table.Column<int>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false),
                    RecurringCycleLength = table.Column<int>(nullable: false),
                    RecurringCyclePeriodId = table.Column<int>(nullable: false),
                    RecurringTotalCycles = table.Column<int>(nullable: false),
                    IsTaxExempt = table.Column<bool>(nullable: false, defaultValue: true),
                    TaxCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct_Pricing", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Pricing_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct_Shipping",
                columns: table => new
                {
                    ShippableId = table.Column<Guid>(nullable: false),
                    IsFreeShipping = table.Column<bool>(nullable: false),
                    AdditionalShippingCharge = table.Column<decimal>(nullable: false),
                    ShipSeparately = table.Column<bool>(nullable: false),
                    DeliveryDateId = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct_Shipping", x => x.ShippableId);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Shipping_CatalogProducts_ShippableId",
                        column: x => x.ShippableId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_AttributeCombinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: true),
                    ManufacturerPartNumber = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    StockQuantity = table.Column<int>(nullable: false),
                    AllowOutOfStockOrders = table.Column<bool>(nullable: false),
                    Gtin = table.Column<string>(nullable: true),
                    OverriddenPrice = table.Column<decimal>(nullable: true),
                    AttributesXml = table.Column<string>(nullable: true),
                    ShippableId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_AttributeCombinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogProducts_AttributeCombinations_CatalogProducts_ShippableId",
                        column: x => x.ShippableId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_Attributes",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    TextPrompt = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    ValidationMinLength = table.Column<int>(nullable: true),
                    ValidationMaxLength = table.Column<int>(nullable: true),
                    ValidationFileAllowedExtensions = table.Column<string>(nullable: true),
                    ValidationFileMaximumSize = table.Column<int>(nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    ConditionAttributeXml = table.Column<string>(nullable: true),
                    AttributeControlType = table.Column<int>(nullable: false),
                    ProductId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_Attributes", x => new { x.ProductId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_Attributes_CatalogProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "CatalogProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogProducts_Attributes_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogProducts_Attributes_CatalogProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_CrossSellProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CrossSellProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_CrossSellProduct", x => new { x.ProductId, x.CrossSellProductId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_CrossSellProduct_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    IsFeaturedProduct = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductCategory_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductDiscount",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductDiscount", x => new { x.ProductId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductDiscount_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductManufacturer",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    IsFeaturedProduct = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductManufacturer", x => new { x.ProductId, x.ManufacturerId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductManufacturer_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductPicture",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductPicture", x => new { x.ProductId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductPicture_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductSpecificationAttribute",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    SpecificationAttributeOptionId = table.Column<Guid>(nullable: false),
                    CustomValue = table.Column<string>(nullable: true),
                    AllowFiltering = table.Column<bool>(nullable: false),
                    ShowOnProductPage = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    AttributeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductSpecificationAttribute", x => new { x.ProductId, x.SpecificationAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductSpecificationAttribute_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductTag",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductTagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductTag", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductTag_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_ProductWarehouseInventory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    WarehouseId = table.Column<Guid>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    ReservedQuantity = table.Column<int>(nullable: false),
                    ShippableId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_ProductWarehouseInventory", x => new { x.ProductId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_ProductWarehouseInventory_CatalogProducts_ShippableId",
                        column: x => x.ShippableId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_RelatedProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    RelatedProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_RelatedProduct", x => new { x.ProductId, x.RelatedProductId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_RelatedProduct_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_RequiredProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    RequiredProductId = table.Column<Guid>(nullable: false),
                    AutomaticallyAddRequiredProducts = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_RequiredProduct", x => new { x.ProductId, x.RequiredProductId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_RequiredProduct_CatalogProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CatalogProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProducts_AttributeValues",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ColorSquaresRgb = table.Column<string>(nullable: true),
                    ImageSquaresPictureId = table.Column<Guid>(nullable: true),
                    PriceAdjustment = table.Column<decimal>(nullable: false),
                    PriceAdjustmentUsePercentage = table.Column<bool>(nullable: false),
                    WeightAdjustment = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    CustomerEntersQty = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsPreSelected = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    AttributeValueTypeId = table.Column<int>(nullable: false),
                    AttributeValueType = table.Column<int>(nullable: false),
                    ProductProductAttributeProductAttributeId = table.Column<Guid>(nullable: false),
                    ProductProductAttributeProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProducts_AttributeValues", x => new { x.ProductId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_CatalogProducts_AttributeValues_CatalogProducts_Attributes_ProductProductAttributeProductId_ProductProductAttributeProductAt~",
                        columns: x => new { x.ProductProductAttributeProductId, x.ProductProductAttributeProductAttributeId },
                        principalTable: "CatalogProducts_Attributes",
                        principalColumns: new[] { "ProductId", "ProductAttributeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissionGrants_Name_ProviderName_ProviderKey",
                table: "AbpPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_NormalizedName",
                table: "AbpRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_Name_ProviderName_ProviderKey",
                table: "AbpSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_RoleId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_Email",
                table: "AbpUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedEmail",
                table: "AbpUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedUserName",
                table: "AbpUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_UserName",
                table: "AbpUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogBackInStockSubscriptions_ProductId",
                table: "CatalogBackInStockSubscriptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCategories_CategoryTemplateId",
                table: "CatalogCategories",
                column: "CategoryTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCategories_ParentCategoryId",
                table: "CatalogCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCategories_CategoryDiscount_CategoryId1",
                table: "CatalogCategories_CategoryDiscount",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogManufacturers_ManufacturerTemplateId",
                table: "CatalogManufacturers",
                column: "ManufacturerTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogManufacturers_ManufacturerDiscount_ManufacturerId1",
                table: "CatalogManufacturers_ManufacturerDiscount",
                column: "ManufacturerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogPredefinedAttributeValues_ProductAttributeId",
                table: "CatalogPredefinedAttributeValues",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogPredefinedAttributeValues_ProductAttributeId1",
                table: "CatalogPredefinedAttributeValues",
                column: "ProductAttributeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_Code",
                table: "CatalogProducts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_ProductTemplateId",
                table: "CatalogProducts",
                column: "ProductTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_ProductType",
                table: "CatalogProducts",
                column: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_AttributeCombinations_ShippableId",
                table: "CatalogProducts_AttributeCombinations",
                column: "ShippableId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_Attributes_ProductAttributeId",
                table: "CatalogProducts_Attributes",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_Attributes_ProductId1",
                table: "CatalogProducts_Attributes",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_AttributeValues_ProductProductAttributeProductId_ProductProductAttributeProductAttributeId",
                table: "CatalogProducts_AttributeValues",
                columns: new[] { "ProductProductAttributeProductId", "ProductProductAttributeProductAttributeId" });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_ProductWarehouseInventory_ShippableId",
                table: "CatalogProducts_ProductWarehouseInventory",
                column: "ShippableId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProducts_StockQuantityHistories_ProductId",
                table: "CatalogProducts_StockQuantityHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogSpecificationAttributeOptions_SpecificationAttributeId",
                table: "CatalogSpecificationAttributeOptions",
                column: "SpecificationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogSpecificationAttributeOptions_SpecificationAttributeId1",
                table: "CatalogSpecificationAttributeOptions",
                column: "SpecificationAttributeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpClaimTypes");

            migrationBuilder.DropTable(
                name: "AbpPermissionGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "CatalogBackInStockSubscriptions");

            migrationBuilder.DropTable(
                name: "CatalogCategories_CategoryDiscount");

            migrationBuilder.DropTable(
                name: "CatalogManufacturers_ManufacturerDiscount");

            migrationBuilder.DropTable(
                name: "CatalogPredefinedAttributeValues");

            migrationBuilder.DropTable(
                name: "CatalogProduct_BasePrice");

            migrationBuilder.DropTable(
                name: "CatalogProduct_Inventory");

            migrationBuilder.DropTable(
                name: "CatalogProduct_Pricing");

            migrationBuilder.DropTable(
                name: "CatalogProduct_Shipping");

            migrationBuilder.DropTable(
                name: "CatalogProducts_AttributeCombinations");

            migrationBuilder.DropTable(
                name: "CatalogProducts_AttributeValues");

            migrationBuilder.DropTable(
                name: "CatalogProducts_CrossSellProduct");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductCategory");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductDiscount");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductManufacturer");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductPicture");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductSpecificationAttribute");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductTag");

            migrationBuilder.DropTable(
                name: "CatalogProducts_ProductWarehouseInventory");

            migrationBuilder.DropTable(
                name: "CatalogProducts_RelatedProduct");

            migrationBuilder.DropTable(
                name: "CatalogProducts_RequiredProduct");

            migrationBuilder.DropTable(
                name: "CatalogProducts_StockQuantityHistories");

            migrationBuilder.DropTable(
                name: "CatalogProductTags");

            migrationBuilder.DropTable(
                name: "CatalogSpecificationAttributeOptions");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "CatalogCategories");

            migrationBuilder.DropTable(
                name: "CatalogManufacturers");

            migrationBuilder.DropTable(
                name: "CatalogProducts_Attributes");

            migrationBuilder.DropTable(
                name: "CatalogSpecificationAttributes");

            migrationBuilder.DropTable(
                name: "CatalogProductAttributes");

            migrationBuilder.DropTable(
                name: "CatalogProducts");

            migrationBuilder.DropTable(
                name: "CatalogViewTemplates");
        }
    }
}
