select n.mNo, 
        n.nTitle, 
        n.nContents, 
        m.mName, 
        DATE_FORMAT(n.regDate, '%Y-%m-%d') as regDate, 
        DATE_FORMAT(n.modDate, '%Y-%m-%d') as modDate		 
  from Notice as n 
 inner join Member as m 
    on (n.mNo = m.mNo and m.delYn = 'N') where n.delYn = 'N';