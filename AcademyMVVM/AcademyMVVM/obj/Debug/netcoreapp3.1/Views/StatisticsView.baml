   M S B A M L   `   `   `  ����F  BAcademyMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AcademyMVVM.ViewsAcademyMVVM.Views  5      ?$clr-namespace:AcademyMVVM.ViewModelsAcademyMVVM.ViewModels  5      &     AcademyMVVM.Views.StatisticsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:AcademyMVVM.Views     5      ;
ViewModels$clr-namespace:AcademyMVVM.ViewModels     5      .��5
      � ���	#FFE5E5E5  � DataContext  5   
   0   *AcademyMVVM.ViewModels.StatisticsViewModel  5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��rtgEsta��5      $	��215��6#   $	��775��60   $��Center=�6<   $	��Top=�6Y   $��0,10,0,0q�6q   ���	#FFB6B6B66�   �� 5   
   -   5        $��lblTituloEst��5      $��Estadíticas:��6$   $
��Left=�6;   $��14��6V   $��	20,20,0,0q�6b   $	��Top=�6u   $	��112��6�   $��10(�6�   $��1,1,1,1q�6�   $��Roboto Medium)�6�   ���	#DDFFFFFF$��0��6�   �� 5   
   -   5        $��	lblPorAsi��5      $��Por Asignatura:��6!   $��20��6;   $��75��6G   $
��Left=�6R   $	��Top=�6m   $��	55,40,0,0q�6�   $��10(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgAsignaturas��5         
IsReadOnly$
 True��6u   $	��150��6�   $	��130��6�   $
��Left=�6�   $	��Top=�6�   $��
140,30,0,0q�6�   $��0��6�   $��Roboto)�6�   $��9(�6     AutoGenerateColumns$ False��6     CanUserAddRows$ False��61     CanUserDeleteRows$ False��6H  ��6(   �� *SubjectsList+ �� SelectedItem 6M   �� *CurrentSubject+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Asignatura��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 69   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6E   �� *Name+6`     5      $ Profesor��6%   $		 100 67   
 6C   �� *	Teacher+6a   5      �� 5   
   -   5        $��btnListarAsi��5      $��15��6L   $��60��6X   $
��Left=�6c   $��Bottom=�6~   $��
140,0,0,20q�6�   $��Listar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6�   $
��True��6  #��� ��62  #��� ��6z  $��0��6�  $��Roboto)�6�  ��6%   �� *GetSubjectsCommand+6�  �� 5   
   -   5        $��btnCalcularxAsi��5      $��15��6T   $��60��6`   $
��Left=�6k   $��Bottom=�6�   $��
210,0,0,20q�6�   $��Calcular��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6  $
��True��6  #��� ��6<  #��� ��6�  $��0��6�  $��Roboto)�6�  ��6(   �� *GetAvgbySubjectsCommand+6�  �� 5   
   -   5        $��	lblPorAlu��5      $��Por Alumno:��6!   $��20��67   $��75��6C   $
��Left=�6N   $	��Top=�6i   $��
300,40,0,0q�6�   $��10(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   �� 5   
   -   5        $��lblDni��5      $
��DNI:��6   $��15��6-   $��50��69   $
��Left=�6D   $	��Top=�6_   $��
300,70,0,0q�6w   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   �� 5    
   -	   5        $��txtDni��5        �� TextWrapping$
 Wrap=�6    $��20��6p   $	��100��6|   $
��Left=�6�   $	��Top=�6�   $��
300,85,0,0q�6�   
�������
�������$��10(�6�   $
��Left=�6  $��Center=�6&  $��Roboto)�6H  ��64   �� *DniVM+ �� UpdateSourceTrigger$ PropertyChanged=�6H  �� 5!   
   -
   5        $��lblApellidos��5!      $��
Apellidos:��6$   $��16��69   $��50��6E   $
��Left=�6P   $	��Top=�6k   $��300,120,0,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $
��Left=�6�   $��Center=�6�   $��Roboto)�6�   �� 5"   
   -   5        $��txtApellidos��5"      $
 Wrap=�6&   $��20��6x   $	��150��6�   $
��Left=�6�   $	��Top=�6�   $��300,135,0,0q�6�   $��10(�6�   $��Center=�6�   $��Roboto)�6  ��6:   �� *	LNameVM+$ PropertyChanged=�6    5#   
   -   5        $��	dgAlumnos��5#      $
 True��6q   $	��150��6�   $	��160��6�   $
��Left=�6�   $	��Top=�6�   $��
465,30,0,0q�6�   $��0��6�   $��Roboto)�6�   $��9(�6  $ False��6  $ False��6-  $ False��6D  ��6$   �� *StudentsList+ 6I   �� *CurrentStudent+ 5$   
     5%      $	 DNI��6%   $	 55 62   
 6=   �� *Dni+6W     5&      $ Nombre Alumno��6%   $		 100 6<   
 6H   �� *	FirstName+6h     5'      $ 	Apellidos��6%   $		 100 68   
 6D   �� *
LastName+6c   5)      �� 5*   
   -   5        $��btnListarAlu��5*      $��15��6L   $��60��6X   $
��Left=�6c   $��Bottom=�6~   $��
495,0,0,20q�6�   $��Buscar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6�   $
��True��6  #��� ��62  #��� ��6z  $��0��6�  $��Roboto)�6�  ��6%   �� *GetStudentsCommand+6�  �� 5+   
   -   5        $��btnCalcularxAlu��5+      $��15��6T   $��60��6`   $
��Left=�6k   $��Bottom=�6�   $��
565,0,0,20q�6�   $��Calcular��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6  $
��True��6  #��� ��6<  #��� ��6�  $��0��6�  $��Roboto)�6�  ��6(   �� *GetAvgbyStudentsCommand+6�  �� 5,   
   -   5        $��
lblNotaMed��5,      $��Nota media:��6"   $��15��68   $��60��6D   $��Right=�6O   $	��Top=�6k   $��	0,45,70,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   �� 5-   
   -   5        $��
txtNotaMed��5-      $
 Wrap=�6$   $��Right=�6x   $��20��6�   $��	0,60,80,0q�6�   $��0��6�   $	��Top=�6�   $��50��6�   $��Center=�6�   $��Center=�6  $��10(�6)  $��Roboto)�67  ${�False��6K  ��68   �� *	NotaMedVM+$ PropertyChanged=�6K  �� 5.   
   -   5        $��
lblNotaMax��5.      $��Nota más alta:��6"   $��15��6;   $��65��6G   $��Right=�6R   $	��Top=�6n   $��	0,95,65,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   �� 5/   
   -   5        $��
txtNotaMax��5/      $
 Wrap=�6$   $��Right=�6x   $��20��6�   $��
0,110,80,0q�6�   $��0��6�   $	��Top=�6�   $��50��6�   $��Center=�6�   $��Center=�6  $��10(�6*  $��Roboto)�68  ${�False��6L  ��68   �� *	NotaMaxVM+$ PropertyChanged=�6L  �� 50   
   -   5        $��
lblNotaMin��50      $��Nota más baja:��6"   $��15��6;   $��65��6G   $��Right=�6R   $	��Top=�6n   $��
0,145,65,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��Roboto)�6�   �� 51   
   -   5        $��
txtNotaMin��51      $
 Wrap=�6$   $��Right=�6x   $��20��6�   $��
0,160,80,0q�6�   $��0��6�   $	��Top=�6�   $��50��6�   $��Center=�6�   $��Center=�6  $��10(�6*  $��Roboto)�68  ${�False��6L  ��68   �� *	NotaMinVM+$ PropertyChanged=�6L  53      54      