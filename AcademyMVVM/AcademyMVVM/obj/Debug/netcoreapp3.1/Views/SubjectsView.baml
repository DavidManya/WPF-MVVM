   M S B A M L   `   `   `  ����F  BAcademyMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AcademyMVVM.ViewsAcademyMVVM.Views  5      ?$clr-namespace:AcademyMVVM.ViewModelsAcademyMVVM.ViewModels  5      $    AcademyMVVM.Views.SubjectsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:AcademyMVVM.Views     5      ;
ViewModels$clr-namespace:AcademyMVVM.ViewModels     5      .��5
      � ���	#FFE5E5E5  � DataContext  5   
   .   (AcademyMVVM.ViewModels.SubjectsViewModel  5       � ColumnDefinitions 5   
   �� 5      $	��51* �6   �� 5      $	��49* �6    � RowDefinitions 5   
   �� 5      $	��230 �6   �� 5      .+�5   
   �� -   5        $��rtgAsi��5      $	��210��6"   $	��380��6/   $��Center=�6;   $��Center=�6X   ���	#FFB6B6B66s   �� 5   
   -   5        $��lblTituloAsi��5      $��Gestión de Asignaturas��6$   $
��Left=�6E   $��14��6`   $��	20,20,0,0q�6l   $	��Top=�6   $	��112��6�   $��10(�6�   $��1,1,1,1q�6�   $��Roboto Medium)�6�   ���	#DDFFFFFF$��0��6�   �� 5   
   -   5        $��lblAsignatura��5      $��Asignatura:��6%   $��15��6;   $��60��6G   $
��Left=�6R   $	��Top=�6m   $��	30,55,0,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��0��6�   $��Roboto)�6�   �� 5   
   -   5        $��txtAsignatura��5       �� TextWrapping$ NoWrap=�6'   $
��Left=�6z   $��20��6�   $��	30,70,0,0q�6�   $��0��6�   $	��Top=�6�   $	��120��6�   $��10(�6�   $��Center=�6�   $��Roboto)�6   �� 	MaxLength$	 100��6)   �� MaxLines$ 1��69  ��6=   �� *NameVM+ �� UpdateSourceTrigger$ PropertyChanged=�69  �� 5   
   -   5        $��
lblNomProf��5      $��Nombre Profesor:��6"   $��15��6=   $��75��6I   $
��Left=�6T   $	��Top=�6o   $��
30,100,0,0q�6�   $��9(�6�   $��2,2,2,2q�6�   $��Center=�6�   $��0��6�   $��Roboto)�6�   �� 5   
   -   5        $��
txtNomProf��5      $ NoWrap=�6$   $
��Left=�6z   $��20��6�   $��
30,115,0,0q�6�   $	��Top=�6�   $	��120��6�   $
��Left=�6�   $��Center=�6�   $��10(�6  $��0��6+  $��Roboto)�68  $	 100��6L  $ 1��6\  ��6:   �� *	TeacherVM+$ PropertyChanged=�6\  &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgAsignaturas��5         
IsReadOnly$
 True��6u   $	��164��6�   $	��200��6�   $
��Left=�6�   $	��Top=�6�   $��
180,20,0,0q�6�   $��0��6�   $��Roboto)�6�   $��9(�6     AutoGenerateColumns$ False��6  	   CanUserAddRows$	 False��61  
   CanUserDeleteRows$
 False��6H  ��6(   �� *SubjectsList+ �� SelectedItem 6M   �� *CurrentSubject+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Asignatura��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+6`     5       $ Profesor��6%   $	 100 67    6C   �� *	Teacher+6a   5"      �� 5#   
   -   5        $��btnBuscarAsi��5#      $��15��6L   $��60��6X   $
��Left=�6c   $	��Top=�6~   $��110,194,0,0q�6�   $��Buscar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6�   $
��True��6  #��� ��60  #��� ��6x  $��0��6�  $��Roboto)�6�  ��6%   �� *GetSubjectsCommand+6�  �� 5$   
   -	   5        $��btnAgregarAsi��5$      $��15��6N   $��60��6Z   $
��Left=�6e   $	��Top=�6�   $��180,194,0,0q�6�   $��Agregar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6�   $
��True��6  #��� ��63  #��� ��6{  $��0��6�  $��Roboto)�6�  ��6&   �� *SaveSubjectsCommand+6�  �� 5%   
   -
   5        $��btnModificarAsi��5%      $��15��6P   $��60��6\   $
��Left=�6g   $	��Top=�6�   $��250,194,0,0q�6�   $��	Modificar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6   $
��True��6  #��� ��67  #��� ��6  $��0��6�  $��Roboto)�6�  ��6(   �� *EditSubjectsCommand+6�  �� 5&   
   -   5        $��btnEliminarAsi��5&      $��15��6N   $��60��6Z   $
��Left=�6e   $	��Top=�6�   $��320,194,0,0q�6�   $��Eliminar��6�   $��9(�6�   $��Normal"�6�   $��LeftToRight=�6�   $��0,0,0,0q�6�   $
��True��6  #��� ��64  #��� ��6|  $��0��6�  $��Roboto)�6�  ��6'   �� *DelSubjectsCommand+6�  5'      5(      