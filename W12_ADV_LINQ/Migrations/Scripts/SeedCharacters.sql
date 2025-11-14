-- Seed Equipments (characters reference equipments)
SET IDENTITY_INSERT [dbo].[Equipments] ON
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (1, 6, 15)   -- Borin: Warhammer + Chainmail
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (2, 1, 10)   -- Town Guard: Short Sword + Shield
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (3, 5, 11)   -- Innkeeper: Club + Padded Cloak
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (4, 2, 9)    -- Merchant: Longsword + Leather Armor
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (5, 3, NULL)   -- Silent Thief: Dagger + Buckler
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (6, 7, 9)    -- Ranger: Short Bow + Leather Armor
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (7, NULL, 15) -- Wizard: no weapon + Padded Cloak
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (8, 16, 11)  -- Dragon Slayer: Great Axe + Plate Armor
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (9, 4, 11)   -- Knight: Greatsword + Plate Armor
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (10, 8, 12)  -- Crossbowman: Crossbow + Shield
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (11, NULL, 9)  -- Apprentice: (uses Buckler as weapon placeholder) + Leather Armor
INSERT INTO [dbo].[Equipments] ([Id], [WeaponId], [ArmorId]) VALUES (12, NULL, NULL)   -- Placeholder equipment (no equipment)
SET IDENTITY_INSERT [dbo].[Equipments] OFF

-- Seed Characters
SET IDENTITY_INSERT [dbo].[Characters] ON
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (1, N'Borin the Blacksmith', 8, 1, 2)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (2, N'Captain Rowan', 12, 2, 5)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (3, N'Marla the Innkeeper', 5, 3, 3)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (4, N'Gideon the Merchant', 6, 4, 4)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (5, N'Silent Thief', 4, 5, 6)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (6, N'Lyra the Ranger', 9, 6, 7)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (7, N'Eldin the Wizard', 14, 7, 12)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (8, N'Arthas the Dragon Slayer', 18, 8, 9)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (9, N'Sir Caldor', 15, 9, 5)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (10, N'Marina the Sailor', 7, 10, 11)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (11, N'Tessa the Apprentice', 3, 11, 12)
INSERT INTO [dbo].[Characters] ([Id], [Name], [Level], [EquipmentId], [RoomId]) VALUES (12, N'Wandering Stranger', 2, 12, NULL)
SET IDENTITY_INSERT [dbo].[Characters] OFF