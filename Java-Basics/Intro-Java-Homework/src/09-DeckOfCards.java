
import com.itextpdf.text.*;
import com.itextpdf.text.pdf.*;

import java.io.FileOutputStream;

public class DeckOfCards {

	public static void main(String[] args) {
		String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		char[] cardSuits = {'\u2660', '\u2663', '\u2665', '\u2666'};
				
		try{
			Document document = new Document();
            PdfWriter.getInstance(document, new FileOutputStream("Deck-of-Cards.pdf"));                      
            document.open();
           
            PdfPTable table = new PdfPTable(8);
            
            table.setWidthPercentage(80);
            table.getDefaultCell().setFixedHeight(70);
            table.getDefaultCell().setHorizontalAlignment(Element.ALIGN_CENTER);
            table.getDefaultCell().setVerticalAlignment(Element.ALIGN_MIDDLE);
                    
            //BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);
            BaseFont baseFont = BaseFont.createFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, true);
            
            Font black = new Font(baseFont, 22f, 1, BaseColor.BLACK);
            Font red   = new Font(baseFont, 22f, 1, BaseColor.RED);
            
            PdfPCell cell = new PdfPCell();
			cell.setBorder(PdfPCell.NO_BORDER);
			
			for(int i = 0; i < cardFaces.length; i++){
				
				for(int j = 0; j < cardSuits.length; j++){
					
					if(j == 0 || j == 1){
						table.addCell(new Paragraph(cardFaces[i]+cardSuits[j] ,black));
						table.addCell(cell);
					}else{
						table.addCell(new Paragraph(cardFaces[i]+cardSuits[j],red));
						table.addCell(cell);
					}
							
				}
				table.setSpacingAfter(40);
				document.add(table);
				table.deleteLastRow();
				
			}
		    document.close();
	
		}
		catch (Exception e) {
		         e.printStackTrace();
        }

	}
}
