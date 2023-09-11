using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantDDD.Domain.HostAggregate.ValueObjects;
using RestaurantDDD.Domain.MenuAggregate;
using RestaurantDDD.Domain.MenuAggregate.Entities;
using RestaurantDDD.Domain.MenuAggregate.ValueObjects;

namespace RestaurantDDD.Infrastructure.Persistence.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib => {

                dib.ToTable("MenuDinnerIds");
                dib.HasKey("Id");
                dib.Property(di => di.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
            
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, midb => {

                midb.ToTable("MenuReviewIds");
                midb.HasKey("Id");
                midb.Property(mi => mi.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id)
               ;
            

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                x => x.Value,
                value => MenuId.Create(value)
                );
            builder.Property(x => x.Name)
                .HasMaxLength(100);
            
            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.OwnsOne(x => x.AverageRating);

            builder.Property(x => x.HostId)
                .HasConversion(
                x => x.Value,
                value => HostId.Create(value)
                );

        }


        private void ConfigureMenuSectionTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(
                m => m.Sections, sb =>
                {
                    sb.ToTable("MenuSections");
                    sb.WithOwner()
                      .HasForeignKey("MenuId");

                    sb.HasKey(nameof(MenuSection.Id), "MenuId");
                    sb.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value)
                        );

                    sb.Property(s => s.Name)
                      .HasMaxLength(100);
                    sb.Property(s => s.Description)
                      .HasMaxLength(200);

                   


                    sb.OwnsMany(sb => sb.Items, ib =>
                    {
                        ib.ToTable("MenuItems");
                        ib.WithOwner()
                        .HasForeignKey("MenuSectionId" , "MenuId");

                        ib.
                        HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                        ib.Property(i => i.Id)
                        .ValueGeneratedNever()
                        .HasColumnName("MenuItemId")
                        .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value)
                       );
                        ib.Property(i => i.Name)
                     .HasMaxLength(100);
                        ib.Property(i => i.Description)
                          .HasMaxLength(200);


                    });
                    sb.Navigation(s => s.Items).
                   Metadata.SetField("_items");

                    // Make EF use the private field
                    sb.Navigation(s => s.Items)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
                }
                );

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

        }

    }
}
