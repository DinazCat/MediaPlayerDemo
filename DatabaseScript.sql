USE [MediaPlayerDB]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Title] [nvarchar](50) NOT NULL,
	[Artist] [nvarchar](50) NOT NULL,
	[Thumbnail] [nvarchar](50) NULL,
	[Year] [nchar](10) NULL,
	[TrackCount] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[Name] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](50) NOT NULL,
	[AlbumCount] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Belong]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Belong](
	[PlaylistName] [nvarchar](50) NOT NULL,
	[SongName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Liked]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liked](
	[UserName] [nvarchar](50) NOT NULL,
	[SongName] [nvarchar](50) NOT NULL,
	[STT] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikedPL]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikedPL](
	[PlaylistName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PLType] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Listenrecently]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Listenrecently](
	[UserName] [nvarchar](50) NOT NULL,
	[SongName] [nvarchar](50) NOT NULL,
	[STT] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MV]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MV](
	[SongName] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[Title] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](50) NOT NULL,
	[Duration] [varchar](10) NULL,
	[Description] [ntext] NULL,
	[UserName] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Song]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[Name] [nvarchar](50) NOT NULL,
	[Artist] [nvarchar](50) NULL,
	[Album] [nvarchar](50) NULL,
	[Duration] [nvarchar](50) NOT NULL,
	[Thumbnail] [nvarchar](50) NOT NULL,
	[Savepath] [nvarchar](50) NOT NULL,
	[Genre] [nvarchar](20) NULL,
	[Nation] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Displayname] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Picture] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPlayingList]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPlayingList](
	[SongName] [nvarchar](50) NOT NULL,
	[Playing] [nchar](10) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[STT] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSongs]    Script Date: 03/02/2023 5:27:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSongs](
	[UserName] [nvarchar](50) NOT NULL,
	[SongName] [nvarchar](50) NOT NULL,
	[Artist] [nvarchar](50) NOT NULL,
	[Duration] [varchar](50) NULL,
	[SavePath] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Harry`s House', N'Harry Styles', N'HarrysHouse.webp', N'2022      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'1989', N'Taylor Swift', N'1989.jpg', N'2014      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Love Yourself: Her', N'BTS', N'LoveYourselfHer.jpg', N'2017      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Narrated For You', N'Alec Benjamin', N'NarratedForYou.webp', N'2018      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Made', N'Big Bang', N'Made.jpg', N'2016      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Fearless', N'Taylor Swift', N'Fearless.png', N'2008      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Original Motion Picture Soundtrack', N'Sufjan Stevens', N'CMBYNSoundTrack.jpg', N'2017      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Cry Baby', N'Melanie Martinez', N'MelanieMartinez.jpg', N'2015      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'You Never Walk Alone', N'BTS', N'YNWA_BTS.jpg', N'2017      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Charlie', N'Charlie Puth', N'Charlie.jpg', N'2022      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Fine Line', N'Harry Styles', N'FineLine.jpg', N'2019      ', NULL)
INSERT [dbo].[Album] ([Title], [Artist], [Thumbnail], [Year], [TrackCount]) VALUES (N'Purpose', N'Justin Bieber', N'Purpose.jpg', N'2015      ', NULL)
GO
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Harry Styles', N'HarryStyles.webp', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Taylor Swift', N'TaylorSwift.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Charlie Puth', N'CharliePuth.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Nhậm Nhiên', N'NhamNhien.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'BTS', N'BTS.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Dhruv', N'Dhruv.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Joji', N'Joji.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Hatsune Miku', N'HatsuneMiku.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Alec Benjamin', N'AlecBenjamin.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Big Bang', N'BigBang.png', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Jay Chou', N'JayChou.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Sufjan Stevens', N'SufjanStevens.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Melanie Martinez', N'MelanieMartinez.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'JungKook-BTS', N'JungKook.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Miu Lê', N'MiuLe.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Mono', N'Mono.png', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'GAYLE', N'GAYLE.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Sơn Tùng M-TP', N'SonTungMTP.webp', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Rod Stewart', N'TheWayYouLookTonight.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Alan Walker', N'AlanWalker.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Justin Bieber', N'JustinBieber.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Mariah Carey', N'AllIWantForChristmasIsYou.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Ava Max', N'AvaMax.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Maroon 5', N'Maroon5.webp', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Đức Phúc', N'NgayDauTien.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Doja Cat', N'DojaCat.jpeg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Gemini', N'KnowMe.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'The Chainsmokers', N'TheChainsmokers.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'DEAMN', N'SaveMe.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'SHAUN', N'SHAUN.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Elvis Presley', N'ElvisPresley.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Frank Sinatra', N'FrankSinatra.webp', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'The Platters', N'ThePlatters.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Joseph Vincent', N'JosephVincent.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Alicia Keys', N'AliciaKeys.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Def Leppard', N'DefLeppard.jpg', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'Yiruma', N'Yiruma.webp', NULL)
INSERT [dbo].[Artist] ([Name], [Picture], [AlbumCount]) VALUES (N'buitruonglinh', N'buitruonglinh.jpg', NULL)
GO
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'If I Killed Someone For You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Play Date')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Still With You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Mystery Of Love')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Blank Space')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Abcdefu')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Fxxk It')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Tát Dã')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'Lạc Trôi')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'As It Was')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Double Take')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Mistletoe')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'My Love Songs', N'Still With You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'All I Want For Christmas Is You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Cheating On You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Kings & Queens')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Sugar')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Vegas')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'When I Get Old')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Waiting For You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Hot Shit')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Know Me')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Die For You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Ngày Đầu Tiên')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Mới Phát Hành', N'Unholy')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Phổ Biến', N'Glimpse Of Us')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'My Love Songs', N'Spring Day')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'My Love Songs', N'Mystery Of Love')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Ahihi', N'Sugar')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'cát tường', N'Chuyện Đôi Ta')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Stay With Me')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Người Theo Đuổi Ánh Sáng')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'My Love Songs', N'Visions Of Gideon')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'cát tường', N'Play Date')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Glimpse Of Us')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'My Love Songs', N'Blank Space')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Can You Hear My Heart')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Ánh Sao Và Bầu Trời')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tâm Trạng', N'Đảo Không Người')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Thư Giãn', N'Visions Of Gideon')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Thư Giãn', N'Kiss The Rain')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Thư Giãn', N'Love Yourself')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Thư Giãn', N'Tada Koe Hitotsu')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Thư Giãn', N'Let`s Not Fall In Love')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tập Trung', N'River Flows In You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tập Trung', N'Flower Dance')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tập Trung', N'Spring Day')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Nhạc Tập Trung', N'Futari No Kimochi')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'BBC Learning English', N'3D Printers')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'BBC Learning English', N'Is Being Kind Good For You')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Đắp chăn nằm nghe Tun kể', N'Công thức 66/3/6/5 giúp bạn thành công sau một năm')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Đắp chăn nằm nghe Tun kể', N'6 công việc giúp sinh viên kiếm thêm thu nhập')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'BBC Learning English', N'Do Trees Have Memories')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Hiếu Nguyễn', N'Lựa chọn nào cũng có đánh đổi')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Hiếu Nguyễn', N'5 mức độ trưởng thành')
INSERT [dbo].[Belong] ([PlaylistName], [SongName]) VALUES (N'Ahihi', N'Abcdefu')
GO
INSERT [dbo].[MV] ([SongName], [Link]) VALUES (N'Lạc Trôi', N'LacTroi.mp4')
INSERT [dbo].[MV] ([SongName], [Link]) VALUES (N'As It Was', N'AsItWas.mp4')
GO
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Pop', N'Pop.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Hàn Quốc', N'NhacHan.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Trung Quốc', N'NhacHoa.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Âu Mỹ', N'NhacAuMy.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Việt Nam', N'NhacViet.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Nhật Bản', N'NhacNhat.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Có Thể Bạn Sẽ Thích', N'CoTheBanSeThich.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Phổ Biến', N'PhoBien.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Mới Phát Hành', N'MoiPhatHanh.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Tâm Trạng', N'TamTrang.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Thư Giãn', N'ThuGian.png', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Tập Trung', N'TapTrung.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc EDM', N'EDM.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Cổ Điển', N'NhacCoDien.jpeg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Phim', N'OST.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc R&B', N'RnB.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Jazz', N'Jazz.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Không Lời', N'NhacKhongLoi.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Nhạc Hip Hop', N'Hiphop.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'BBC Learning English', N'BBC.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Đắp chăn nằm nghe Tun kể', N'TunPham.jpg', NULL, NULL, NULL)
INSERT [dbo].[Playlist] ([Title], [Picture], [Duration], [Description], [UserName]) VALUES (N'Hiếu Nguyễn', N'HieuNguyen.jpg', NULL, NULL, NULL)
GO
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'As It Was', N'Harry Styles', N'Harry`s House', N'2:47', N'AsItWas.jpg', N'AsItWas.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Blank Space', N'Taylor Swift', N'1989', N'3:51', N'BlankSpace.jpg', N'BlankSpace.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Cheating On You', N'Charlie Puth', NULL, N'3:16', N'CheatingOnYou.jpg', N'CheatingOnYou.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Chuyện Đôi Ta', N'Emcee L(DALAB)', NULL, N'3:28', N'ChuyenDoiTa.jpg', N'ChuyenDoiTa.mp3', N'VPop', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Đảo Không Người', N'Nhậm Nhiên', N'Tình yêu không xảy ra', N'4:45', N'DaoKhongNguoi.jpg', N'DaoKhongNguoi.mp3', N'Nhạc Hoa', N'Trung Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'DNA', N'BTS', N'Love Yourself: Her', N'3:43', N'BTS.jpg', N'DNA.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Don`t Let Me Down', N'The Chainsmokers', NULL, N'3:28', N'DontLetMeDown.jpg', N'DontLetMeDown.mp3', N'EDM', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Double Take', N'Dhruv', NULL, N'2:52', N'Dhruv.jpg', N'DoubleTake.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Futari No Kimochi', N'Wada Kaoru', NULL, N'2:39', N'Inuyasha.jpg', N'FutariNoKimochi.mp3', N'Nhạc Không Lời', N'Nhật Bản')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Glimpse Of Us', N'Joji', NULL, N'3:53', N'Joji.jpg', N'GlimpseOfUs.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Hazy Moon', N'Hatsune Miku', NULL, N'4:15', N'HatsuneMiku.jpg', N'HazyMoon.mp3', N'Nhạc Nhật', N'Nhật Bản')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'If I Killed Someone For You', N'Alec Benjamin', N'Narrated For You', N'3:05', N'IfIKilledSomeoneForYou.jpg', N'IfIKilledSomeoneForYou.mp3', N'Indie', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Let Me Down Slowly', N'Alec Benjamin', N'Narrated For You', N'2:49', N'LetMeDownSlowly.jpg', N'LetMeDownSlowly.mp3', N'Indie', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Loser', N'Big Bang', N'Made', N'3:39', N'Loser.jpg', N'Loser.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Love Story', N'Taylor Swift', N'Fearless', N'3:55', N'LoveStory.jpg', N'LoveStory.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Mojito', N'Jay Chou', NULL, N'3:05', N'JayChou.jpg', N'Mojito.mp3', N'Nhạc Hoa', N'Trung Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Mystery Of Love', N'Sufjan Stevens', N'Original Motion Picture Soundtrack', N'4:08', N'MysteryOfLove.jpg', N'MysteryOfLove.mp3', N'Acoustic', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Visions Of Gideon', N'Sufjan Stevens', N'Original Motion Picture Soundtrack', N'4:07', N'CallMeByYourName.jpg', N'VisionsOfGideon.mp3', N'Acoustic', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Play Date', N'Melanie Martinez', N'Cry Baby', N'2:59', N'MelanieMartinez.jpg', N'PlayDate.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Spring Day', N'BTS', N'You Never Walk Alone', N'4:34', N'SpringDay.jpg', N'SpringDay.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Stay With Me', N'Chanyeol, Punch', NULL, N'3:13', N'StayWithMe.jpg', N'StayWithMe.mp3', N'Nhạc Phim', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Still With You', N'JungKook - BTS', NULL, N'4:01', N'JungKook.jpg', N'StillWithYou.mp3', N'Jazz', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Tát Dã', N'Khải Sắt Miêu', NULL, N'4:08', N'TatDa.jpg', N'TatDa.mp3', N'Nhạc Phim', N'Trung Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Unravel', N'Kitajima Toru', NULL, N'3:58', N'KenKaneki.jpg', N'Unravel.mp3', N'Nhạc Phim', N'Nhật Bản')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Vì Mẹ Anh Bắt Chia Tay', N'Miu Lê', NULL, N'4:22', N'MiuLe.jpg', N'ViMeAnhBatChiaTay.mp3', N'VPop', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Waiting For You', N'Mono', NULL, N'4:25', N'Mono.png', N'WaitingForYou.mp3', N'VPop', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Bae Bae', N'Big Bang', N'Made', N'2:49', N'BaeBae.jpg', N'BaeBae.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Fxxk It', N'Big Bang', N'Made', N'3:51', N'FxxkIt.png', N'FxxkIt.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Let`s Not Fall In Love', N'Big Bang', N'Made', N'3:31', N'LetsNotFallInLove.jpg', N'LetsNotFallInLove.mp3', N'KPop', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Lời Tạm Biệt Chưa Nói', N'GREY-D, Orange', NULL, N'4:19', N'LoiTamBietChuaNoi.jpg', N'LoiTamBietChuaNoi.mp3', N'VPop', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'That`s Hilarious', N'Charlie Puth', N'Charlie', N'2:25', N'ThatsHilarious.jpg', N'ThatsHilarious.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Abcdefu', N'GAYLE', NULL, N'2:48', N'Abcdefu.jpg', N'Abcdefu.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Lạc Trôi', N'Sơn Tùng M-TP', NULL, N'4:20', N'LacTroi.jpg', N'LacTroi.mp3', N'R&B', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Light Switch', N'Charlie Puth', N'Charlie', N'3:07', N'LightSwitch.jpg', N'LightSwitch.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'The Way You Look Tonight', N'Rod Stewart', NULL, N'3:49', N'TheWayYouLookTonight.jpg', N'TheWayYouLookTonight.mp3', N'Jazz', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Lily', N'Alan Walker', NULL, N'3:15', N'Lily.jpg', N'Lily.mp3', N'EDM', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Mistletoe', N'Justin Bieber', N'Under The Mistletoe', N'3:02', N'Mistletoe.jpg', N'Mistletoe.mp3', N'R&B', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'All I Want For Christmas Is You', N'Mariah Carey', NULL, N'3:58', N'AllIWantForChristmasIsYou.jpg', N'AllIWantForChristmasIsYou.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Kings & Queens', N'Ava Max', NULL, N'2:42', N'Kings&Queens.png', N'Kings&Queens.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Sugar', N'Maroon 5', NULL, N'3:54', N'Sugar.jpg', N'Sugar.mp3', N'Rock', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Ngày Đầu Tiên', N'Đức Phúc', NULL, N'3:28', N'NgayDauTien.jpg', N'NgayDauTien.mp3', N'R&B', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Vegas', N'Doja Cat', NULL, N'3:02', N'Vegas.jpg', N'Vegas.mp3', N'Hip Hop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Tada Koe Hitotsu', N'Rokudenashi', NULL, N'2:42', N'TadaKoeHitotsu.jpg', N'TadaKoeHitotsu.mp3', N'Nhạc Nhật', N'Nhật Bản')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Unholy', N'Sam Smith, Kim Petras', NULL, N'2:36', N'Unholy.jpg', N'Unholy.mp3', N'R&B', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Hot Shit', N'CardiB, LilDurk, KanyeWest', NULL, N'3:31', N'HotShit.jpeg', N'HotShit.mp3', N'Hip Hop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'When I Get Old', N'Christopher, Kim Chung-ha', NULL, N'3:04', N'WhenIGetOld.jpg', N'WhenIGetOld.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Flower Dance', N'DJ Okawari', NULL, N'4:23', N'FlowerDance.jpg', N'FlowerDance.mp3', N'Nhạc Không Lời', N'Nhật Bản')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Know Me', N'Gemini', NULL, N'3:34', N'KnowMe.jpg', N'KnowMe.mp3', N'R&B', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Die For You', N'Joji', NULL, N'3:31', N'DieForYou.jpg', N'DieForYou.mp3', N'R&B', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Faded', N'Alan Walker', NULL, N'3:32', N'Faded.jpg', N'Faded.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Closer', N'The Chainsmokers', NULL, N'4:05', N'Closer.png', N'Closer.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Symphony', N'Clean Bandit, Zara Larsson', NULL, N'3:32', N'Symphony.jpg', N'Symphony.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Alone', N'Alan Walker', NULL, N'2:38', N'Alone.jpg', N'Alone.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'So Far Away', N'David Guetta, Martin Garrix', NULL, N'3:03', N'SoFarAway.jpg', N'SoFarAway.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Save Me', N'DEAMN', NULL, N'3:04', N'SaveMe.jpg', N'SaveMe.mp3', N'EDM', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Way Back Home', N'SHAUN', NULL, N'3:34', N'WayBackHome.jpg', N'WayBackHome.mp3', N'EDM', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Shallow', N'Lady Gaga, Bradley Cooper', NULL, N'3:35', N'Shallow.jpg', N'Shallow.mp3', N'Nhạc Phim', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Everytime', N'Chen, Punch', NULL, N'3:09', N'Everytime.jpg', N'Everytime.mp3', N'Nhạc Phim', N'Hàn QUốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Người Theo Đuổi Ánh Sáng', N'Từ Vi', NULL, N'3:44', N'NguoiTheoDuoiAnhSang.jpg', N'NguoiTheoDuoiAnhSang.mp3', N'Nhạc Phim', N'Trung Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'I See The Light', N'Mandy Moore, Zachary Levi', NULL, N'3:43', N'ISeeTheLight.jpg', N'ISeeTheLight.mp3', N'Nhạc Phim', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Can You Hear My Heart', N'Epik High, Lee Hi', NULL, N'4:08', N'CanYouHearMyHeart.jpg', N'CanYouHearMyHeart.mp3', N'Nhạc Phim', N'Hàn Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Can`t Help Falling In Love', N'Elvis Presley', NULL, N'3:18', N'CantHelpFallingInLove.jpg', N'CantHelpFallingInLove.mp3', N'Cổ Điển', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Fly Me To The Moon', N'Frank Sinatra', NULL, N'2:32', N'FlyMeToTheMoon.jpg', N'FlyMeToTheMoon.mp3', N'Cổ Điển', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Fly Me To The Moon', N'Frank Sinatra', NULL, N'2:32', N'FlyMeToTheMoon.jpg', N'FlyMeToTheMoon.mp3', N'Jazz', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'I Love You Baby', N'Frank Sinatra', NULL, N'3:46', N'ILoveYouBaby.jpg', N'ILoveYouBaby.mp3', N'Cổ Điển', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Yesterday Once More', N'The Carpenters', NULL, N'4:01', N'YesterdayOnceMore.jpg', N'YesterdayOnceMore.mp3', N'Cổ Điển', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Only You', N'The Platters', NULL, N'2:37', N'OnlyYou.jpg', N'OnlyYou.mp3', N'Cổ Điển', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Can`t Take My Eyes Off You', N'Joseph Vincent', NULL, N'2:43', N'CantTakeMyEyesOffYou.jpg', N'CantTakeMyEyesOffYou.mp3', N'Cổ Điển', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Can`t Take My Eyes Off You', N'Joseph Vincent', NULL, N'2:43', N'CantTakeMyEyesOffYou.jpg', N'CantTakeMyEyesOffYou.mp3', N'Jazz', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'If I Ain`t Got You', N'Alicia Keys', NULL, N'3:51', N'IfIAintGotYou.jpg', N'IfIAintGotYou.mp3', N'Jazz', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Ánh Sao Và Bầu Trời', N'T.R.I', NULL, N'4:20', N'AnhSaoVaBauTroi.jpg', N'AnhSaoVaBauTroi.mp3', N'VPop', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Vong Tiện', N'Tiêu Chiến, Vương Nhất Bác', NULL, N'4:13', N'VongTien.jpg', N'VongTien.mp3', N'Nhạc Phim', N'Trung Quốc')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Two Steps Behind', N'Def Leppard', NULL, N'4:19', N'TwoStepsBehind.jpg', N'TwoStepsBehind.mp3', N'Acoustic', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Dù Cho Mai Về Sau', N'buitruonglinh', NULL, N'3:33', N'DuChoMaiVeSau.jpg', N'DuChoMaiVeSau.mp3', N'Acoustic', N'Việt Nam')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Kiss The Rain', N'Yiruma', NULL, N'4:19', N'KissTheRain.jpg', N'KissTheRain.mp3', N'Nhạc Không Lời', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'River Flows In You', N'Yiruma', NULL, N'3:08', N'RiverFlowsInYou.jpg', N'RiverFlowsInYou.mp3', N'Nhạc Không Lời', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Forever', N'Hòa tấu', NULL, N'2:55', N'Forever.jpg', N'Forever.mp3', N'Nhạc Không Lời', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Past Lives', N'Violin', NULL, N'5:42', N'PastLives.jpg', N'PastLives.mp3', N'Nhạc Không Lời', NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Shake It Off', N'Taylor Swift', N'1989', N'3:39', N'ShakeItOff.jpg', N'ShakeItOff.mp3', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Watermelon Sugar', N'Harry Styles', N'Fine Line', N'2:54', N'WatermelonSugar.jpg', N'WatermelonSugar.mp3', N'Pop', N'Âu Mỹ')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Falling', N'Harry Styles', N'Fine Line', N'4:00', N'Falling.jpg', N'Falling.mp3', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'So Am I', N'Ava Max', NULL, N'3:03', N'SoAmI.png', N'SoAmI.mp3', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Love Yourself', N'Justin Bieber', N'Purpose', N'3:53', N'LoveYourself.jpg', N'LoveYourself.mp3', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Công thức 66/3/6/5 giúp bạn thành công sau một năm', N'Tun Phạm', NULL, N'11:00', N'TunPham.jpg', N'TunPhams29.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'6 công việc giúp sinh viên kiếm thêm thu nhập', N'Tun Phạm', NULL, N'18:00', N'TunPham.jpg', N'TunPhams30.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Kia Con Buom Vang', N'Xuan Mai', N'', N'00:02:03.8016875', N'Default.jpeg', N'nlKiaConBuomVang-XuanMai_rc6r.mp3', N'', N'')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'3D Printers', N'6 Minute English', NULL, N'6:21', N'3DPrinters.jpg', N'3Dprinters.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Is Being Kind Good For You', N'6 Minute English', NULL, N'6:20', N'IsBeingKindGoodForYou.jpg', N'IsBeingKindGoodForYou.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Do Trees Have Memories', N'6 Minute English', NULL, N'6:20', N'DoTreesHaveMemories.jpg', N'DoTreesHaveMemories.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Lựa chọn nào cũng có đánh đổi', N'Hiếu Nguyễn', NULL, N'14:30', N'LuaChonNaoCungCoDanhDoi.jpg', N'LuaChonNaoCungCoDanhDoi.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'5 mức độ trưởng thành', N'Hiếu Nguyễn', NULL, N'14:20', N'5MucDoTruongThanh.jpg', N'5MucDoTruongThanh.mp4', NULL, NULL)
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Film Out', N'BTS', N'', N'00:03:34.6507499', N'Default.jpeg', N'zincat510Film Out - BTS.mp3', N'', N'')
INSERT [dbo].[Song] ([Name], [Artist], [Album], [Duration], [Thumbnail], [Savepath], [Genre], [Nation]) VALUES (N'Photograph', N'Ed Sheeran', N'', N'04:19', N'Default.jpeg', N'zincat510Photograph - Ed Sheeran.mp3', N'', N'')
GO
