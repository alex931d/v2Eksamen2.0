   M S B A M L   `   `   `  ����E  ABookLibary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BookLibary
BookLibary  5          BookLibary.booksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:BookLibary     5        N� Title$  	booksPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $	��64* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	BooksGrid��5   %      
IsReadOnly . $
��Left=�68   $	��230��6T   $	��Top=�6a   $	��516��6y   $��2��6�   �� 5   
   -   5        $��create��5      $
��Left=�6"   $��24,180.8,0,0q�6=   $	��Top=�6S   $��75��6k   $��1��6�   �� 5   
   -   5        $��update��5      $
��Left=�6"   $��104,180.8,0,0q�6=   $	��Top=�6T   $��75��6l   $��1��6�   �� 5   
   -   5        $��delete��5      $
��Left=�6"   $��441,65.8,0,0q�6=   $	��Top=�6S   $��75��6k   $��1��6�   �� 5   
   -   5         ��Name$ 	authorBox��5      $
��Left=�6%   $��23��6@   $��
0,93.8,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   $��1��6�   �� 5   
   $��author��6   $
��Left=�6!   $��
0,71.8,0,0q�6<   $	��Top=�6P   $��1��6h   �� 5   
   -   5        $ titleBox��5      $
��Left=�6$   $��23��6?   $��125,93.8,0,0q�6K   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   $��1��6�   �� 5   
   $��title��6   $
��Left=�6    $��125,71.8,0,0q�6;   $	��Top=�6Q    J� RenderTransformOrigin$ 0.792,3.217&�6i   $��1��6�   �� 5   
   -   5        $ publisherBox��5      $
��Left=�6(   $��23��6C   $��0,143.8,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   $��1��6�   �� 5   
   $��	publisher��6   $
��Left=�6$   $��0,121.8,0,0q�6?   $	��Top=�6T   $��1��6l   �� 5   
   $
��year��6   $
��Left=�6   $��125,121.8,0,0q�6:   $	��Top=�6Q   $��1��6i   �� 5   
   -   5        $ countBox��5      $
��Left=�6$   $��23��6?   $��250,143.8,0,0q�6K   $
 Wrap=�6b   $	��Top=�6v   $��40��6�   $��1��6�   �� 5   
   $��count��6   $
��Left=�6    $��250,121.8,0,0q�6;   $	��Top=�6R   $��1��6j   �� 5   
   -	   5        $ ISBNBox��5      $
��Left=�6#   $��23��6>   $��295,143.8,0,0q�6J   $
 Wrap=�6a   $	��Top=�6u   $	��175��6�   $��1��6�   �� 5   
   $
��ISBN��6   $
��Left=�6   $��295,121.8,0,0q�6:   $	��Top=�6Q   $��1��6i   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ datepickerYear��5      $
��Left=�6-   $��125,143.8,0,0q�6H   $��1��6_   $	��Top=�6l   $	��120��6�   5!      5"      