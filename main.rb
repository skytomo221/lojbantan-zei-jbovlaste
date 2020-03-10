# frozen_string_literal: true

i = 14
File.open('test.txt', 'w') do |text|
  File.open('backi.txt', mode = 'rt') do |f|
    f.each_line do |line|
      text.puts("\#\#\# Version 0.#{i}\n\n- #{line.chomp!}の追加\n\n")
      i = i.next
    end
  end
end
