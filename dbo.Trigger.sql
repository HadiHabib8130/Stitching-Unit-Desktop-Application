CREATE TRIGGER [ComputeTotal]
	ON [dbo].[tbl_ItemAccs]
	FOR DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;
		update tbl_ItemAccs set Total = Price * Quantity
	END
