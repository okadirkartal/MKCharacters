namespace MKCharacters.API.Models
{
    using Microsoft.EntityFrameworkCore;
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "T-800 Endoskeleton Arm" },
            new Equipment { Id = 2, Name = "Red Headband" },
            new Equipment { Id = 3, Name = "Razor Sai" },
              new Equipment { Id = 4, Name = "Military Test" },
            new Equipment { Id = 5, Name = "Freddy's Glove" },
            new Equipment { Id = 6, Name = "Celestial Blow" },
              new Equipment { Id = 7, Name = "Body Armor" },
            new Equipment { Id = 8, Name = "Combat Shotgun" },
            new Equipment { Id = 9, Name = "Riot Gear" },
              new Equipment { Id = 10, Name = "Medallion" },
            new Equipment { Id = 11, Name = "Soul Elixir" },
            new Equipment { Id = 12, Name = "Healing Debts" },
              new Equipment { Id = 13, Name = "Gladiator Mask" }
            );

            modelBuilder.Entity<Character>().HasData(new Character { Id = 1, EquipmentId = 1, Name = "Ermac", Variant = "Outworld", Damage = 100, IsAvailable = true },
              new Character { Id = 2, EquipmentId = 1, Name = "Scorpion", Variant = "Martial Artist", Damage = 200, IsAvailable = true },
              new Character { Id = 3, EquipmentId = 2, Name = "Mileena", Variant = "Martial Artist", Damage = 300, IsAvailable = true },
              new Character { Id = 4, EquipmentId = 2, Name = "Sub-Zero", Variant = "Martial Artist", Damage = 400, IsAvailable = true },
              new Character { Id = 5, EquipmentId = 3, Name = "Kung Jin", Variant = "Martial Artist", Damage = 500, IsAvailable = true },
              new Character { Id = 6, EquipmentId = 3, Name = "Kotal Kahn", Variant = "Outworld", Damage = 600, IsAvailable = true },
              new Character { Id = 7, EquipmentId = 4, Name = "Reptile", Variant = "outworld", Damage = 700, IsAvailable = true },
              new Character { Id = 8, EquipmentId = 4, Name = "Kenshi", Variant = "Martial Artist/Spec Ops", Damage = 800, IsAvailable = true },
              new Character { Id = 9, EquipmentId = 5, Name = "Cassie Cage", Variant = "Spec Ops", Damage = 900, IsAvailable = true },
              new Character { Id = 10, EquipmentId = 5, Name = "Bo'rai Cho", Variant = "Martial Artist", Damage = 150, IsAvailable = true },
              new Character { Id = 11, EquipmentId = 6, Name = "Oni", Variant = "Netherrealm", Damage = 250, IsAvailable = false },
              new Character { Id = 12, EquipmentId = 6, Name = "Kano", Variant = "Outworld", Damage = 350, IsAvailable = true },
              new Character { Id = 13, EquipmentId = 7, Name = "Johnny Cage", Variant = "Spec Ops", Damage = 450, IsAvailable = true },
              new Character { Id = 14, EquipmentId = 7, Name = "Jax Brigs", Variant = "Spec Ops", Damage = 550, IsAvailable = true },
              new Character { Id = 15, EquipmentId = 8, Name = "Dworah", Variant = "Outworld", Damage = 650, IsAvailable = true },
              new Character { Id = 16, EquipmentId = 8, Name = "Saurioan", Variant = "Outworkd", Damage = 750, IsAvailable = true },
              new Character { Id = 17, EquipmentId = 9, Name = "Jacqui Briggs", Variant = "Spec Ops", Damage = 850, IsAvailable = true },
              new Character { Id = 18, EquipmentId = 9, Name = "Lin Kuei", Variant = "Martial Artist", Damage = 950, IsAvailable = true },
              new Character { Id = 19, EquipmentId = 10, Name = "Shirai Ryu", Variant = "Martial Artist", Damage = 125, IsAvailable = true },
              new Character { Id = 20, EquipmentId = 10, Name = "Monk", Variant = "Martial Artist", Damage = 225, IsAvailable = true },
              new Character { Id = 21, EquipmentId = 11, Name = "Sergeant", Variant = "Spec Ops", Damage = 325, IsAvailable = true },
              new Character { Id = 22, EquipmentId = 11, Name = "Trooper", Variant = "Spec Ops", Damage = 425, IsAvailable = true },
              new Character { Id = 23, EquipmentId = 12, Name = "Osh Tekk", Variant = "Outworld", Damage = 525, IsAvailable = true },
              new Character { Id = 24, EquipmentId = 12, Name = "Sindel", Variant = "Netherrealm/Outworld", Damage = 625, IsAvailable = true },
              new Character { Id = 25, EquipmentId = 13, Name = "Kitana", Variant = "Outworld", Damage = 725, IsAvailable = true });
        }
    }
}